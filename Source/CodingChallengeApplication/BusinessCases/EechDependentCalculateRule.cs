namespace CodingChallengeApplication.BusinessCases
{
    internal class EechDependentCalculateRule : ICalculateRule
    {
        private readonly INameStartsWithADiscount _nameStartsWithADiscount ;

        public EechDependentCalculateRule(INameStartsWithADiscount nameStartsWithADiscount)
        {
            _nameStartsWithADiscount = nameStartsWithADiscount;
        }

        public double Calculate(Employee employee, double current)
        {
            foreach (var dependent in employee.Dependents)
            {
                var cost = 500d;
                cost = _nameStartsWithADiscount.CalculateDiscount(dependent.Name, cost);
                current += cost;
            }
            return current;
        }

        public int Priority => 100;
    }
}