using System;
using System.IO;
using LiteDB;

namespace CodingChallengeApplication.LiteDbModule
{
    internal class DatabaseFactory : IDatabaseFactory
    {
        public LiteDatabase Create()
        {
            return new LiteDatabase(Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(),"CodingChallengeData.db"));
        }
    }
}