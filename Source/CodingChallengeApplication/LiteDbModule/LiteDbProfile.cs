using AutoMapper;

namespace CodingChallengeApplication.LiteDbModule
{
    internal class LiteDbProfile : Profile
    {
        public LiteDbProfile()
        {
            CreateMap<Employee, LIteDbEmployee>();
            CreateMap<LIteDbEmployee, Employee>();
        }
    }
}