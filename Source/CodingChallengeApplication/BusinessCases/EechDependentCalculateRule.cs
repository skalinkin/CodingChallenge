namespace CodingChallengeApplication.BusinessCases
{
    internal class EechDependentCalculateRule : ICalculateRule
    {
        public double Calculate(Employee employee, double current)
        {
            foreach (var dependent in employee.Dependents)
            {
                current += 500;
            }
            return current;
        }

        public int Priority => 100;
    }
}