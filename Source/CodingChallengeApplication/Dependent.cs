using System;

namespace CodingChallengeApplication
{
    public class Dependent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DependentType DependentType { get; set; }
    }
}