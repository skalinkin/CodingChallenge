using CodingChallengeApplication;

namespace WebHost.Models
{
    public class EmployeeWithDeduction
    {
        public Employee Employee { get; set; }
        public string YearDeduction { get; set; }
        public string PaycheckDeduction { get; set; }
        public string EmplyeeRecieves { get; set; }
    }
}