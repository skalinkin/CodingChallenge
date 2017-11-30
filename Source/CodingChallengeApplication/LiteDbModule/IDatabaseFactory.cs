using LiteDB;

namespace CodingChallengeApplication.LiteDbModule
{
    internal interface IDatabaseFactory
    {
        LiteDatabase Create();
    }
}