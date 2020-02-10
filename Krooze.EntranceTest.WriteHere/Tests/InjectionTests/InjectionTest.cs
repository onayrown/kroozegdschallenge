using System;
using System.Collections.Generic;
using Krooze.EntranceTest.WriteHere.Structure.Model;
using Krooze.EntranceTest.WriteHere.Structure.Implementations;

namespace Krooze.EntranceTest.WriteHere.Tests.InjectionTests
{
    public class InjectionTest
    {
        public List<CruiseDTO> GetCruises(CruiseRequestDTO request)
        {
            //TODO: This method receives a generic request, that has a cruise company code on it
            //There is an interface (IGetCruise) that is implemented by 3 classes (Company1, Company2 and Company3)
            //Make sure that the correct class is injected based on the CruiseCompanyCode on the request
            //without directly referencing the 3 classes and the method GetCruises of the chosen implementation is called

            switch (request.CruiseCompanyCode)
            {
                case 1:
                    return new Company1().GetCruises(request);
                case 2:
                    return new Company2().GetCruises(request);
                case 3:
                    return new Company3().GetCruises(request);
                default:
                    throw new Exception(string.Format($"Company Code '{request.CruiseCompanyCode}' is not valid."));
            }
        }
    }
}
