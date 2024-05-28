﻿using System.Xml.Serialization;

namespace AggregateReader.BlueriqObjects
{
    [XmlRoot("entity")]
    public class BlueriqProfileExportXmlEntity
    {
        [XmlAttribute("instanceid")]
        public string? InstanceId { get; set; }

        [XmlAttribute("name")]
        public string? Name { get; set; }

        [XmlElement("attribute")]
        public List<BlueriqProfileExportXmlAttribute>? Attributes { get; set; }
    }
}
