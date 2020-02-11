using Krooze.EntranceTest.WriteHere.Structure.Model;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Xml.Serialization;
using System.Reflection;

namespace Krooze.EntranceTest.WriteHere.Tests.LogicTests
{
    public class XMLTest
    {
        public CruiseDTO TranslateXML()
        {
            //TODO: Take the Cruises.xml file, on the Resources folder, and translate it to the CruisesDTO object,
            //you can do it in any way, including intermediary objects

            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("Cruises.xml"));

            string xmlString = GetResourceFile(resourceName);
            var cruiseDTO = Deserialize<CruiseDTO>(xmlString);

            foreach (var item in cruiseDTO.PassengerCruise)
            {
                var cabinValue = item.Charges.FirstOrDefault(x => x.ChargeType == "CAB").GrossAmount;
                var portCharge = item.Charges.FirstOrDefault(x => x.ChargeType == "PCH").GrossAmount;

                item.Cruise = new CruiseDTO();
                item.Cruise.ShipName = cruiseDTO.ShipName;
                item.Cruise.CruiseCode = cruiseDTO.CruiseCode;
                item.Cruise.CabinValue = cabinValue;
                item.Cruise.PortCharge = portCharge;
                item.Cruise.TotalValue = item.AllInclusivePerPax;
            }

            return cruiseDTO;
        }

        public string GetResourceFile(string resourceName)
        {
            string result = string.Empty;

            using (Stream stream = this.GetType().Assembly.
                       GetManifestResourceStream(resourceName))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    result = sr.ReadToEnd();
                }
            }
            return result;
        }

        public T Deserialize<T>(string input) where T : class
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute("Cruises"));

            using (StringReader sr = new StringReader(input))
            {
                return (T)serializer.Deserialize(sr);
            }
        }
    }
}
