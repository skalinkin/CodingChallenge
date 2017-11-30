using Autofac;
using AutoMapper;

namespace CodingChallengeApplication.LiteDbModule
{
    public class LiteDbModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>();
            builder.RegisterType<EmployeeStorage>().As<IEmployeeStorage>();

            Mapper.Initialize(cfg => {
                cfg.AddProfile<LiteDbProfile>();
            });
        }

    }
}