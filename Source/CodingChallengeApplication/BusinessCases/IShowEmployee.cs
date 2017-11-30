using System;

namespace CodingChallengeApplication.BusinessCases
{
    public interface IShowEmployee
    {
        Employee Find(Guid id);
    }
}