using AggregateReader.BlueriqObjects;
using AggregateReader.Parsers.XmlAggregate;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AggregateReader.Parsers.XmlProfileExport
{
    public class ParserXmlProfileExportToBlueriqAggregate : IBlueriqParser
    {
        bool IBlueriqParser.CanIdentifyRootNodes => false;

        public BlueriqAggregate Parse(string xml)
        {
            // Deserialize the XML to Profile object
            XmlSerializer serializer = new(typeof(XmlProfileExportProfile));
            XmlProfileExportProfile? profile;
            using (StringReader reader = new(xml))
            {
                profile = (XmlProfileExportProfile?)serializer.Deserialize(reader);
            }

            if (profile == null) return new BlueriqAggregate() { Type = string.Empty, Entities = [] };

            // Create BlueriqAggregate
            BlueriqAggregate aggregate = new()
            {
                Type = profile.AppName ?? string.Empty,
                Entities = []
            };

            if (profile.Entities == null) return aggregate;

            // Map Profile Entities to BlueriqEntities
            Dictionary<string, BlueriqEntity> entityMap = profile.Entities.ToDictionary(
                e => e.InstanceId ?? string.Empty,
                e => new BlueriqEntity
                {
                    Type = e.Name ?? string.Empty,
                    Id = e.InstanceId ?? string.Empty,
                    Attributes = [],
                    Relations = [],
                    ParentRelations = []
                });

            // Populate Attributes and Relations
            foreach (XmlProfileExportEntity entity in profile.Entities)
            {
                BlueriqEntity blueriqEntity = entityMap[entity.InstanceId ?? string.Empty];

                if (entity.Attributes == null) continue;

                foreach (XmlProfileExportAttribute attribute in entity.Attributes)
                {
                    AddAttributeOrRelation(blueriqEntity, attribute, entityMap);
                }

                blueriqEntity.Attributes.Sort();
                blueriqEntity.Relations.Sort();
            }


            // Add Entities to Aggregate
            aggregate.Entities.AddRange(entityMap.Values);

            ParserXmlAggregateToBlueriqAggregate.SetEntityIndices(aggregate);

            aggregate.Entities.Sort();

            return aggregate;
        }

        private static void AddAttributeOrRelation(
            BlueriqEntity entity, XmlProfileExportAttribute xmlAttribute, Dictionary<string, BlueriqEntity> entityMap)
        {
            string cleanName = xmlAttribute.Name == null ? string.Empty : xmlAttribute.Name.Split('.').Last();

            string firstValue = "";
            if (xmlAttribute.Values != null && xmlAttribute.Values.Count > 0) firstValue = xmlAttribute.Values[0];
            if (xmlAttribute.Value != null) firstValue = xmlAttribute.Value;

            if (firstValue.EndsWith('|'))
            {
                // It's a relation
                BlueriqRelation relation = new()
                {
                    Name = cleanName,
                    Multivalue = "false",
                    ParentEntity = entity,
                    Values = [],
                    Children = []

                };
                entity.Relations.Add(relation);

                if (xmlAttribute.Values != null) relation.Values = xmlAttribute.Values;
                if (xmlAttribute.Value != null) relation.Values.Add(xmlAttribute.Value);

                List<string> parsedValues = [];
                foreach (string value in relation.Values)
                {
                    string[] parts = value.Split('|');
                    if (parts.Length != 3) continue;

                    parsedValues.Add(parts[1]);
                    foreach (BlueriqEntity loopEntity in entityMap.Values)
                    {
                        if (loopEntity.Type == parts[0] && loopEntity.Id == parts[1])
                        {
                            relation.Children.Add(loopEntity);
                            loopEntity.ParentRelations.Add(relation);
                        }
                    }
                }
                relation.Values = parsedValues;

                SetAttributeDerivationType(xmlAttribute, relation);
            }
            else
            {
                // It's an attribute
                BlueriqAttribute attribute = new()
                {
                    Name = cleanName,
                    Multivalue = xmlAttribute.Values != null && xmlAttribute.Values.Count > 1 ? "true" : "false",
                    ParentEntity = entity,
                    Values = []
                };

                SetAttributeDerivationType(xmlAttribute, attribute);

                if (xmlAttribute.Values != null) attribute.Values = xmlAttribute.Values;
                if (xmlAttribute.Value != null) attribute.Values.Add(xmlAttribute.Value);

                entity.Attributes.Add(attribute);
            }


        }

        private static void SetAttributeDerivationType(XmlProfileExportAttribute xmlAttribute, BlueriqAttribute attribute)
        {
            if (xmlAttribute.Source == "USER") attribute.DerivationType = DerivationType.UserSet;
            if (xmlAttribute.Source == "UNKNOWN") attribute.DerivationType = DerivationType.DerivedUnknown;
            if (xmlAttribute.Source == "DEFAULT") attribute.DerivationType = DerivationType.DerivedDefaultValue;
            if (xmlAttribute.Source == "SYSTEM") attribute.DerivationType = DerivationType.DerivedSystem;
        }

        public bool CanParse(string xml)
        {
            try
            {
                XDocument doc = XDocument.Parse(xml);
                var rootElement = doc.Root;

                if (rootElement != null)
                {
                    bool isProfileElement = rootElement.Name.LocalName == "profile";
                    bool hasAppName = !string.IsNullOrWhiteSpace(rootElement.Attribute("appName")?.Value);

                    return isProfileElement && hasAppName;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }

    }
}