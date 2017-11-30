namespace CodingChallengeApplication.BusinessCases
{
    internal interface INameStartsWithADiscount
    {
        double CalculateDiscount(string name, double cost);
    }
}