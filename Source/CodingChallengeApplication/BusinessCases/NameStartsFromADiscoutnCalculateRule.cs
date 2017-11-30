using System;

namespace CodingChallengeApplication.BusinessCases
{
    internal class NameStartsFromADiscoutnCalculateRule : ICalculateRule
    {
        public int Priority => 1000;

        public double Calculate(Employee employee, double current)
        {
            if (employee.Name.StartsWith("A", StringComparison.InvariantCultureIgnoreCase))
            {
                current = current * 0.9;
            }
            return current;
        }
    }
}