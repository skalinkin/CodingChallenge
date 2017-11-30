using System;
using System.Collections.Generic;

namespace CodingChallengeApplication.LiteDbModule
{
    internal class LIteDbEmployee
    {
        public Guid Id { get; set; }
        public IEnumerable<Dependent> Dependents { get; set; }
        public string Name { get; set; }
    }
}