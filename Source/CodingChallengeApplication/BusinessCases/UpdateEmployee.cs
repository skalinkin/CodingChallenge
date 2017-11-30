namespace CodingChallengeApplication.BusinessCases
{
    internal class UpdateEmployee : IUpdateEmployee
    {
        private readonly IEmployeeStorage _storage;

        public UpdateEmployee(IEmployeeStorage storage)
        {
            _storage = storage;
        }
        public void Update(Employee employee)
        {
            _storage.Update(employee);
        }
    }
}