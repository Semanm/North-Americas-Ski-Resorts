using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace NorthAmericasSkiResorts.Models
{
    [XmlRoot("SkiResorts")]
    public class SkiResorts
    {
        [XmlElement("SkiResort")]
        public List<SkiResort> skiResorts;
    }
}