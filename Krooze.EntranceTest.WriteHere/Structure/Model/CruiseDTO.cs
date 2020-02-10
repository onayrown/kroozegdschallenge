using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Krooze.EntranceTest.WriteHere.Structure.Model
{
    /// <summary>
    /// Cruise Transfer Object
    /// </summary>

    [XmlRoot(ElementName = "Cruises")]
    [Serializable]
    public class CruiseDTO
    {
        [XmlElement("CruiseId")]
        public string CruiseCode { get; set; }
        /// <summary>
        /// Total Value of the Cruise
        /// </summary>
        [XmlElement("TotalCabinPrice")]
        public decimal TotalValue { get; set; }
        /// <summary>
        /// Total Cabin (CAB) Value
        /// </summary>
        [XmlElement("CabinPrice")]
        public decimal CabinValue { get; set; }
        /// <summary>
        /// Total Port Charge (PCH) Value
        /// </summary>
        [XmlElement("PortChargesAmt")]
        public decimal PortCharge { get; set; }
        /// <summary>
        /// Ship Name
        /// </summary>
        [XmlElement("ShipName")]
        public string ShipName { get; set; }
        [XmlArray("CategoryPriceDetails")]
        [XmlArrayItem("Pax")]
        public List<PassengerCruiseDTO> PassengerCruise { get; set; }

    }

    public class PassengerCruiseDTO
    {
        public CruiseDTO Cruise { get; set; }
        [XmlAttribute("PaxID")]
        public string PassengerCode { get; set; }
        [XmlElement("Charge")]
        public List<ChargesDTO> Charges { get; set; }
        [XmlElement("AllInclusivePerPax")]
        public decimal AllInclusivePerPax { get; set; }
    }

    public class ChargesDTO
    {
        [XmlAttribute("ChargeType")]
        public string ChargeType { get; set; }
        [XmlElement("GrossAmount")]
        public decimal GrossAmount { get; set; }
    }
}
