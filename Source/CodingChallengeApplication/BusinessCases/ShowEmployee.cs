using System;

namespace CodingChallengeApplication.BusinessCases
{
    internal class ShowEmployee : IShowEmployee
    {
        private readonly IEmployeeStorage _storage;

        public ShowEmployee(IEmployeeStorage storage)
        {
            _storage = storage;
        }

        public Employee Find(Guid id)
        {
            return _storage.Find(id);
        }
    }
}