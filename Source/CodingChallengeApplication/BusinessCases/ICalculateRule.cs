namespace CodingChallengeApplication.BusinessCases
{
    internal interface ICalculateRule
    {
        int Priority { get; }
        double Calculate(Employee employee, double current);
    }
}