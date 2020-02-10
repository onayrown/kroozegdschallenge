using Krooze.EntranceTest.WriteHere.Structure.Model;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Xml.Serialization;

namespace Krooze.EntranceTest.WriteHere.Tests.LogicTests
{
    public class XMLTest
    {
        public CruiseDTO TranslateXML()
        {
            //TODO: Take the Cruises.xml file, on the Resources folder, and translate it to the CruisesDTO object,
            //you can do it in any way, including intermediary objects

            XElement xmlFile = XElement.Load(@"Resources\Cruises.xml");
            string xmlString = xmlFile.ToString();
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
