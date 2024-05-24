using AggregateReader.BlueriqObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregateReader.BlueriqXml
{
    public static class BlueriqXmlAggregateParser
    {
        public static BlueriqAggregate ParseXmlToAggregate(BlueriqXmlAggregate xmlAggregate)
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
                    entity.OnlyOneInstanceOfThisTypeExists = (group.Count() == 1);
                }
            }
        }
    }
}
