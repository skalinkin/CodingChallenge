using System.Linq;
using CodingChallengeApplication;
using CodingChallengeApplication.BusinessCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace UnitTest
{
    [TestClass]
    public class ShowEmployeeTest
    {
        [TestMethod]
        public void GetAllReturnsTwoEmployee()
        {
            var storage = Substitute.For<IEmployeeStorage>();
            var employees = new[] {new Employee(), new Employee()};
            storage.GetAll().Returns(employees);

            var businessCase = new ShowEmployees(storage);
            var result = businessCase.GetAll();
            Assert.IsTrue(result.Count() == 2);
        }
    }
}