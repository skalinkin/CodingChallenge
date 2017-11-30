using System.Collections.Generic;
using System.Linq;

namespace CodingChallengeApplication.BusinessCases
{
    class CalculatePreviewStrategy : ICalculatePreviewStrategy
    {
        private readonly IEnumerable<ICalculateRule> _rules;

        public CalculatePreviewStrategy(IEnumerable<ICalculateRule> rules)
        {
            _rules = rules;
        }

        public double Calculate(Employee employee)
        {
            double result = 0;

            foreach (var rule in _rules.OrderBy(r => r.Priority))
            {
                result = rule.Calculate(employee, result);
            }

            return result;
        }
    }
}