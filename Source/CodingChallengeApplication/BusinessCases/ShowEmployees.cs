using System.Collections.Generic;

namespace CodingChallengeApplication.BusinessCases
{
    internal class ShowEmployees : IShowEmployees
    {
        private readonly IEmployeeStorage _storage;

        public ShowEmployees( IEmployeeStorage storage)
        {
            _storage = storage;
        }
        public IEnumerable<Employee> GetAll()
        {
            return _storage.GetAll();
        }
    }
}