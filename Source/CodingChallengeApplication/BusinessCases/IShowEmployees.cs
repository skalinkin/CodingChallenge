using System.Collections.Generic;

namespace CodingChallengeApplication.BusinessCases
{
    public interface IShowEmployees
    {
        IEnumerable<Employee> GetAll();
    }
}