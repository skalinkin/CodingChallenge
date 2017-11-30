using CodingChallengeApplication;
using CodingChallengeApplication.BusinessCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class CostPerYearCalculateRuleTest
    {
        [TestMethod]
        public void CalculateReturnsOneThousend()
        {
            var rule = new CostPerYearCalculateRule();
            Employee employee = new Employee();
            var expected = 1000;
            Assert.AreEqual( expected, rule.Calculate(employee, 0));
        }
    }
}