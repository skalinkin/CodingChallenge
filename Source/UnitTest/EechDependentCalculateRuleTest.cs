using CodingChallengeApplication;
using CodingChallengeApplication.BusinessCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace UnitTest
{
    [TestClass]
    public class EechDependentCalculateRuleTest
    {
        [TestMethod]
        public void CalculateReturnsOneThousend()
        {
            INameStartsWithADiscount discountRule = NSubstitute.Substitute.For<INameStartsWithADiscount>();
            discountRule.CalculateDiscount(null, 500).Returns(500);
            var rule = new EechDependentCalculateRule(discountRule);
            Employee employee = new Employee();
            employee.Dependents.Add(new Dependent());
            employee.Dependents.Add(new Dependent());
            var expected = 1000;
            Assert.AreEqual( expected, rule.Calculate(employee, 0));
        }
    }
}