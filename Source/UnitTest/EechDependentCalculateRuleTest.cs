using CodingChallengeApplication;
using CodingChallengeApplication.BusinessCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class EechDependentCalculateRuleTest
    {
        [TestMethod]
        public void CalculateReturnsOneThousend()
        {
            var rule = new EechDependentCalculateRule();
            Employee employee = new Employee();
            employee.Dependents.Add(new Dependent());
            employee.Dependents.Add(new Dependent());
            var expected = 1000;
            Assert.AreEqual( expected, rule.Calculate(employee, 0));
        }
    }
}