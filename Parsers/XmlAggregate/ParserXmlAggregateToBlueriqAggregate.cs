using AggregateReader.BlueriqObjects;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AggregateReader.Parsers.XmlAggregate
{
    public class ParserXmlAggregateToBlueriqAggregate : IBlueriqParser
    {
        bool IBlueriqParser.CanIdentifyRootNodes => true;
        public BlueriqAggregate Parse(string xml)
        {
            XmlAggregate? xmlAggregate;
            using TextReader reader = new StringReader(xml);
            XmlSerializer serializer = new(typeof(XmlAggregate));
            xmlAggregate = serializer.Deserialize(reader) as XmlAggregate;

            if (xmlAggregate == null) return new BlueriqAggregate() { Type = string.Empty, Entities = [] };

            return ParseXmlToAggregate(xmlAggregate);
        }

        public BlueriqAggregate ParseXmlToAggregate(XmlAggregate xmlAggregate)
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
                            ParentEntity = entity,
                            DerivationType = DerivationType.UserSet
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
            
            SetEntityIndices(aggregate);

            aggregate.Entities.Sort();

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
            foreach (BlueriqEntity entity in aggregate.Entities)
            {
                foreach (BlueriqRelation relation in entity.Relations)
                {
                    relation.Children?.Sort();
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
            foreach (BlueriqEntity entity in aggregate.Entities)
            {
                foreach (BlueriqRelation relation in entity.Relations)
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
