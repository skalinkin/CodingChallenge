using System;
using System.Collections.Generic;

namespace CodingChallengeApplication
{
    internal interface IEmployeeStorage
    {
        IEnumerable<Employee> GetAll();
        void Insert(Employee employee);
        Employee Find(Guid id);
        void Update(Employee employee);
        void Delete(Guid id);
    }
}