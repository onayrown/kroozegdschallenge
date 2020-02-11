using Krooze.EntranceTest.WriteHere.Structure.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krooze.EntranceTest.WriteHere.Structure.Interfaces
{
    public interface ITestsService
    {
        List<CruiseDTO> GetCruises(CruiseRequestDTO request);
        decimal? GetOtherTaxes(CruiseDTO cruise);
        bool? IsThereDiscount(CruiseDTO cruise);
        int? GetInstallments(decimal fullPrice);
        CruiseDTO TranslateXML();
        JObject GetAllMovies();
        string GetDirector();
    }
}
