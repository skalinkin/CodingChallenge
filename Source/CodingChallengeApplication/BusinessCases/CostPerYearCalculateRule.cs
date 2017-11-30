namespace CodingChallengeApplication.BusinessCases
{
    internal class CostPerYearCalculateRule : ICalculateRule
    {
        public int Priority => 50;

        public double Calculate(Employee employee, double current)
        {
            current += 1000;
            return current;
        }
    }
}