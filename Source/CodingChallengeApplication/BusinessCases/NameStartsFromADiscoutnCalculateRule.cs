using System;

namespace CodingChallengeApplication.BusinessCases
{
    internal class NameStartsFromADiscoutnCalculateRule : INameStartsWithADiscount
    {
        public int Priority => 1000;

        public double CalculateDiscount(string name, double cost)
        {
            if (name.StartsWith("A", StringComparison.InvariantCultureIgnoreCase))
            {
               cost  = cost * 0.9;
            }
            return cost; ;
        }
    }
}