using System;
using System.Collections.Generic;

namespace CodingChallengeApplication.LiteDbModule
{
    internal class EmployeeStorage: IEmployeeStorage
    {
        private readonly IDatabaseFactory _factory;

        public EmployeeStorage(IDatabaseFactory factory)
        {
            _factory = factory;
        }
        public IEnumerable<Employee> GetAll()
        {
            using (var database = _factory.Create())
            {
                var employees = database.GetCollection<LIteDbEmployee>("employees");
                foreach (var employee in employees.FindAll())
                {
                    var map = AutoMapper.Mapper.Map<Employee>(employee);
                    yield return map;
                }
            }
        }

        public void Insert(Employee employee)
        {
            var doc = AutoMapper.Mapper.Map<LIteDbEmployee>(employee);

            using (var database = _factory.Create())
            {
                var employees = database.GetCollection<LIteDbEmployee>("employees");
                employees.Insert(doc);
                employees.EnsureIndex(x => x.Id);
                employees.EnsureIndex(x => x.Name);
            }
        }

        public Employee Find(Guid id)
        {
            using (var database = _factory.Create())
            {
                var employees = database.GetCollection<LIteDbEmployee>("employees");
                var doc = employees.FindOne(e => e.Id == id);

                var employee = AutoMapper.Mapper.Map<Employee>(doc);
                return employee;
            }
        }

        public void Update(Employee employee)
        {
            using (var database = _factory.Create())
            {
                var employees = database.GetCollection<LIteDbEmployee>("employees");
                var doc = AutoMapper.Mapper.Map<LIteDbEmployee>(employee);

                employees.Update(doc);
            }
        }

        public void Delete(Guid id)
        {
            using (var database = _factory.Create())
            {
                var employees = database.GetCollection<LIteDbEmployee>("employees");
                employees.Delete(x => x.Id == id);
            }
        }
    }
}