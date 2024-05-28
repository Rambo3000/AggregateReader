using AggregateReader.BlueriqObjects;
using AggregateReader.Parsers.BlueriqXml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AggregateReader.Parsers
{
    public class ParserXmlAggregate : IBlueriqParser
    {
        bool IBlueriqParser.CanIdentifyRootNodes => true;
        public BlueriqAggregate Parse(string xml)
        {
            BlueriqXmlAggregate? xmlAggregate;
            using TextReader reader = new StringReader(xml);
            XmlSerializer serializer = new(typeof(BlueriqXmlAggregate));
            xmlAggregate = serializer.Deserialize(reader) as BlueriqXmlAggregate;

            if (xmlAggregate == null) return null;

            return ParseXmlToAggregate(xmlAggregate);
        }

        public BlueriqAggregate ParseXmlToAggregate(BlueriqXmlAggregate xmlAggregate)
        {
            BlueriqAggregate aggregate = new()
            {
                Type = xmlAggregate.Type
            };

            foreach (var xmlEntity in xmlAggregate.Entities)
            {
                BlueriqEntity entity = new()
                {
                    Type = xmlEntity.Type ?? string.Empty,
                    Id = xmlEntity.Id ?? string.Empty,
                    Relations = [],
                    Attributes = []
                };

                if (xmlEntity.Attributes != null)
                {
                    // Parse attributes
                    foreach (var xmlAttribute in xmlEntity.Attributes)
                    {
                        BlueriqAttribute attribute = new()
                        {
                            Name = xmlAttribute.Name,
                            Multivalue = xmlAttribute.Multivalue,
                            ParentEntity = entity
                        };

                        // Check if attribute has multiple values
                        if (xmlAttribute.Values != null && xmlAttribute.Values.Count != 0)
                        {
                            attribute.Values = xmlAttribute.Values;
                        }

                        if (xmlAttribute.Value != null && !string.IsNullOrEmpty(xmlAttribute.Value))
                        {
                            attribute.Values ??= [];
                            attribute.Values.Add(xmlAttribute.Value);
                        }

                        entity.Attributes.Add(attribute);
                    }
                    entity.Attributes.Sort();
                }

                if (xmlEntity.Relations != null)
                {
                    // Parse relations
                    foreach (var xmlRelation in xmlEntity.Relations)
                    {
                        BlueriqRelation relation = new()
                        {
                            Name = xmlRelation.Name,
                            Multivalue = xmlRelation.Multivalue,
                            ParentEntity = entity
                        };

                        // Check if relation has multiple values
                        if (xmlRelation.Values != null && xmlRelation.Values.Count != 0)
                        {
                            relation.Values = xmlRelation.Values;
                        }

                        if (xmlRelation.Value != null && !string.IsNullOrEmpty(xmlRelation.Value))
                        {
                            relation.Values ??= [];
                            relation.Values.Add(xmlRelation.Value);
                        }

                        entity.Relations.Add(relation);
                    }
                    entity.Relations.Sort();
                }

                aggregate.Entities ??= [];
                aggregate.Entities.Add(entity);
            }
            aggregate.Entities.Sort();

            SetEntityIndices(aggregate);

            PopulateRelationChildren(aggregate);
            return aggregate;
        }
        public static void SetEntityIndices(BlueriqAggregate aggregate)
        {
            List<IGrouping<string, BlueriqEntity>> groupedEntities = aggregate.Entities.GroupBy(e => e.Type).ToList();

            foreach (IGrouping<string, BlueriqEntity> group in groupedEntities)
            {
                int index = 1;
                foreach (BlueriqEntity entity in group)
                {
                    entity.Index = index++;
                    entity.OnlyOneInstanceOfThisTypeExists = group.Count() == 1;
                }
            }
        }

        public bool CanParse(string xml)
        {
            try
            {
                XDocument doc = XDocument.Parse(xml);
                var rootElement = doc.Root;
                if (rootElement != null)
                {
                    var type = rootElement.Attribute("type")?.Value;
                    return rootElement.Name == "aggregate";
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        public static void PopulateRelationChildren(BlueriqAggregate aggregate)
        {
            foreach (var entity in aggregate.Entities)
            {
                foreach (var relation in entity.Relations)
                {
                    // Check if relation has values
                    if (relation.Values != null && relation.Values.Count != 0)
                    {
                        relation.ParentEntity = entity;

                        // Find matching entities based on relation values
                        relation.Children = aggregate.Entities.Where(e => relation.Values.Contains(e.Id)).ToList();
                        foreach (var childEntity in relation.Children)
                        {
                            childEntity.ParentRelations ??= [];
                            childEntity.ParentRelations.Add(relation);
                        }
                    }
                }
            }
        }
    }
}
