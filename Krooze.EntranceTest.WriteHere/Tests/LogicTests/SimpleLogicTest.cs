using Krooze.EntranceTest.WriteHere.Structure.Model;
using System;
using System.Linq;

namespace Krooze.EntranceTest.WriteHere.Tests.LogicTests
{
    public class SimpleLogicTest
    {
        public decimal? GetOtherTaxes(CruiseDTO cruise)
        {
            //TODO: Based on the CruisesDTO object, gets if there is some other tax that not the port charge

            var otherTax = cruise.TotalValue - (cruise.CabinValue + cruise.PortCharge);

            return otherTax;
        }

        public bool? IsThereDiscount(CruiseDTO cruise)
        {
            //TODO: Based on the CruisesDTO object, check if the second passenger has some kind of discount, based on the first passenger price
            //Assume there are always 2 passengers on the list                    

            return cruise.PassengerCruise.FirstOrDefault().Cruise.CabinValue
                <= cruise.PassengerCruise.LastOrDefault().Cruise.CabinValue ? false : true;
        }

        public int? GetInstallments(decimal fullPrice)
        {
            //TODO: Based on the full price, find the max number of installments
            // -The absolute max number is 12
            // -The minimum value of the installment is 200

            int installments = Convert.ToInt32(fullPrice / 200);

            if (fullPrice < 200)
                return 1;
            if (fullPrice > 2400)
                return 12;


            return installments;
        }
    }
}
