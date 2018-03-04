using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using NorthAmericasSkiResorts.Models;
using System.IO;

namespace NorthAmericasSkiResorts.DataAccessLayer
{

    public class SkiResortXmlDataService : ISkiResortDataService, IDisposable
    {
        public List<SkiResort> Read()
        {
            // a SkiResorts model is defined to pass a type to the XmlSerializer object 
            SkiResorts SkiResortsObject;

            // initialize a FileStream object for reading
            string xmlFilePath = HttpContext.Current.Application["dataFilePath"].ToString();
            StreamReader sReader = new StreamReader(xmlFilePath);

            // initialize an XML seriailizer object
            XmlSerializer deserializer = new XmlSerializer(typeof(SkiResorts));

            using (sReader)
            {
                // deserialize the XML data set into a generic object
                object xmlObject = deserializer.Deserialize(sReader);

                // cast the generic object to the list class
                SkiResortsObject = (SkiResorts)xmlObject;
            }

            return SkiResortsObject.skiResorts;
        }

        public void Write(List<SkiResort> SkiResorts)
        {
            // initialize a FileStream object for reading
            string xmlFilePath = HttpContext.Current.Application["dataFilePath"].ToString();
            StreamWriter sWriter = new StreamWriter(xmlFilePath, false);

            XmlSerializer serializer = new XmlSerializer(typeof(List<SkiResort>), new XmlRootAttribute("SkiResorts"));

            using (sWriter)
            {
                serializer.Serialize(sWriter, SkiResorts);
            }
        }

        public void Dispose()
        {
            // set resources to be cleaned up
        }
    }
}