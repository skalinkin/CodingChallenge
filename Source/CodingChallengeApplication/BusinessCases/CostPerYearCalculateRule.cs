using System;

namespace CodingChallengeApplication.BusinessCases
{
    internal class CostPerYearCalculateRule : ICalculateRule
    {
        private readonly INameStartsWithADiscount _nameStartsWithADiscount ;

        public CostPerYearCalculateRule(INameStartsWithADiscount nameStartsWithADiscount)
        {
            _nameStartsWithADiscount = nameStartsWithADiscount;
        }

        public int Priority => 50;

        public double Calculate(Employee employee, double current)
        {
            var cost = 1000d;
            cost = _nameStartsWithADiscount.CalculateDiscount(employee.Name, cost);
            return current + cost;
        }
    }
}