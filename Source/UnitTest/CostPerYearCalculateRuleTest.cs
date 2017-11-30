using CodingChallengeApplication;
using CodingChallengeApplication.BusinessCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace UnitTest
{
    [TestClass]
    public class CostPerYearCalculateRuleTest
    {
        [TestMethod]
        public void CalculateReturnsOneThousend()
        {
            INameStartsWithADiscount discountRule = NSubstitute.Substitute.For<INameStartsWithADiscount>();
            discountRule.CalculateDiscount(null, 1000).Returns(1000);
            var rule = new CostPerYearCalculateRule(discountRule);
            Employee employee = new Employee();
            var expected = 1000;
            Assert.AreEqual( expected, rule.Calculate(employee, 0));
        }
    }
}