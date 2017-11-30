using System;

namespace CodingChallengeApplication.BusinessCases
{
    internal class DeleteEmployee : IDeleteEmployee
    {
        private readonly IEmployeeStorage _storage;

        public DeleteEmployee(IEmployeeStorage storage)
        {
            _storage = storage;
        }

        public void Delete(Guid id)
        {
            _storage.Delete(id);
        }
    }
}