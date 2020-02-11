using Krooze.EntranceTest.WriteHere.Structure.Interfaces;
using Krooze.EntranceTest.WriteHere.Structure.Model;
using Krooze.EntranceTest.WriteHere.Tests.InjectionTests;
using Krooze.EntranceTest.WriteHere.Tests.LogicTests;
using Krooze.EntranceTest.WriteHere.Tests.WebTests;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krooze.EntranceTest.WriteHere.Services
{    
    public class TestsService : ITestsService
    {
        private readonly WebTest _webTest;
        private readonly XMLTest _xMLTest;
        private readonly SimpleLogicTest _simpleLogicTest;
        private readonly InjectionTest _injectionTest;

        public TestsService(WebTest webTest, XMLTest xMLTest, SimpleLogicTest simpleLogicTest, InjectionTest injectionTest)
        {
            _webTest = webTest;
            _xMLTest = xMLTest;
            _simpleLogicTest = simpleLogicTest;
            _injectionTest = injectionTest;
        }

        public JObject GetAllMovies()
        {
            return _webTest.GetAllMovies();
        }        

        public string GetDirector()
        {
            return _webTest.GetDirector();
        }

        public List<CruiseDTO> GetCruises(CruiseRequestDTO request)
        {
            return _injectionTest.GetCruises(request);
        }

        public int? GetInstallments(decimal fullPrice)
        {
            return _simpleLogicTest.GetInstallments(fullPrice);
        }

        public decimal? GetOtherTaxes(CruiseDTO cruise)
        {
            return _simpleLogicTest.GetOtherTaxes(cruise);
        }

        public bool? IsThereDiscount(CruiseDTO cruise)
        {
            return _simpleLogicTest.IsThereDiscount(cruise);
        }

        public CruiseDTO TranslateXML()
        {
            return _xMLTest.TranslateXML();
        }
    }
}
