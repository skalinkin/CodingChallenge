namespace CodingChallengeApplication.BusinessCases
{
    internal class CalculatePreviewOfTheCost
    {
        private readonly ICalculatePreviewStrategy _strategy;
        public Employee Employee { get; set; }

        public CalculatePreviewOfTheCost(ICalculatePreviewStrategy strategy )
        {
            _strategy = strategy;
        }

        public double Calculate()
        {
            var result = _strategy.Calculate(Employee);
            return result;
        }
    }
}