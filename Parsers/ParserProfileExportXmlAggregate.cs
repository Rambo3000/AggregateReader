using AggregateReader.BlueriqObjects;
using AggregateReader.Parsers.BlueriqProfileExportXml;
using AggregateReader.Parsers;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;
using System.Xml.Serialization;

public class ParserProfileExportXmlAggregate : IBlueriqParser
{
    bool IBlueriqParser.CanIdentifyRootNodes => false;

    public BlueriqAggregate Parse(string xml)
    {
        // Deserialize the XML to Profile object
        XmlSerializer serializer = new(typeof(BlueriqProfileExportXmlProfile));
        BlueriqProfileExportXmlProfile profile;
        using (StringReader reader = new(xml))
        {
            profile = (BlueriqProfileExportXmlProfile)serializer.Deserialize(reader);
        }

        // Create BlueriqAggregate
        BlueriqAggregate aggregate = new BlueriqAggregate
        {
            Type = profile.AppName,
            Entities = new List<BlueriqEntity>()
        };

        // Map Profile Entities to BlueriqEntities
        var entityMap = profile.Entities.ToDictionary(
            e => e.InstanceId,
            e => new BlueriqEntity
            {
                Type = e.Name,
                Id = e.InstanceId,
                Attributes = new List<BlueriqAttribute>(),
                Relations = new List<BlueriqRelation>(),
                ParentRelations = new List<BlueriqRelation>()
            });

        // Populate Attributes and Relations
        foreach (var entity in profile.Entities)
        {
            var blueriqEntity = entityMap[entity.InstanceId];
            foreach (var attribute in entity.Attributes)
            {
                AddAttributeOrRelation(blueriqEntity, attribute, entityMap);
            }
            blueriqEntity.Attributes.Sort();
            blueriqEntity.Relations.Sort();
        }


        // Add Entities to Aggregate
        aggregate.Entities.AddRange(entityMap.Values);

        aggregate.Entities.Sort();
        ParserXmlAggregate.SetEntityIndices(aggregate);

        return aggregate;
    }

    private static void AddAttributeOrRelation(
        BlueriqEntity entity, BlueriqProfileExportXmlAttribute xmlAttribute, Dictionary<string, BlueriqEntity> entityMap)
    {
        string cleanName = xmlAttribute.Name.Split('.').Last();

        string firstValue = "";
        if (xmlAttribute.Values != null && xmlAttribute.Values.Count() > 0) firstValue = xmlAttribute.Values[0];
        if (xmlAttribute.Value != null) firstValue = xmlAttribute.Value;

        if (firstValue.EndsWith('|'))
        {
            // It's a relation
            BlueriqRelation relation = new BlueriqRelation
            {
                Name = cleanName,
                Multivalue = "false",
                ParentEntity = entity,

            };
            entity.Relations.Add(relation);

            var parts = firstValue.Split('|');
            if (parts.Length > 1 && entityMap.TryGetValue(parts[1], out var relatedEntity))
            {
                relation.Children = [relatedEntity];
                relatedEntity.ParentRelations.Add(relation);
            }
        }
        else
        {
            // It's an attribute
            BlueriqAttribute attribute = new BlueriqAttribute
            {
                Name = cleanName,
                Multivalue = (xmlAttribute.Values != null && xmlAttribute.Values.Count() > 1) ? "true" : "false",
                ParentEntity = entity,
                Values = []
            };

            if (xmlAttribute.Values != null) attribute.Values = xmlAttribute.Values;
            if (xmlAttribute.Value != null) attribute.Values.Add(xmlAttribute.Value);

            entity.Attributes.Add(attribute);
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
                var appName = rootElement.Attribute("appName")?.Value;
                return appName == "RootEntry";
            }
        }
        catch (Exception)
        {
            return false;
        }
        return false;
    }

}