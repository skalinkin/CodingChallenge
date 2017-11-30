using System;
using System.Collections.Generic;

namespace CodingChallengeApplication
{
    public class Employee
    {
        public Employee()
        {
            Dependents = new List<Dependent>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Dependent> Dependents { get; set; }
    }
}