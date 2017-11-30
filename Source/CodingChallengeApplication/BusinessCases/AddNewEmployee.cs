namespace CodingChallengeApplication.BusinessCases
{
    internal class AddNewEmployee : IAddNewEmployee
    {
        private readonly IEmployeeStorage _storage;

        public AddNewEmployee(IEmployeeStorage storage)
        {
            _storage = storage;
        }
        public void Insert(Employee employee)
        {
            _storage.Insert(employee);
        }
    }
}