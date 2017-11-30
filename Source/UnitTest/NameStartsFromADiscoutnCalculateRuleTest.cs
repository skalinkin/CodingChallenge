using CodingChallengeApplication;
using CodingChallengeApplication.BusinessCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class NameStartsFromADiscoutnCalculateRuleTest
    {
        [TestMethod]
        public void CalculateReturnsNineHundred()
        {
            var rule = new NameStartsFromADiscoutnCalculateRule();
            Employee employee = new Employee() {Name = "Arron"};
            var expected = 900;
            Assert.AreEqual( expected, rule.Calculate(employee, 1000));
        }
    }
}