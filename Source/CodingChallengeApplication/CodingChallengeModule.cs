using Autofac;
using CodingChallengeApplication.BusinessCases;

namespace CodingChallengeApplication
{
    public class CodingChallengeModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ShowEmployees>().As<IShowEmployees>();
            builder.RegisterType<AddNewEmployee>().As<IAddNewEmployee>();
            builder.RegisterType<ShowEmployee>().As<IShowEmployee>();
            builder.RegisterType<DeleteEmployee>().As<IDeleteEmployee>();
            builder.RegisterType<UpdateEmployee>().As<IUpdateEmployee>();
            builder.RegisterType<CalculatePreviewStrategy>().As<ICalculatePreviewStrategy>();
            builder.RegisterType<CostPerYearCalculateRule>().As<ICalculateRule>();
            builder.RegisterType<EechDependentCalculateRule>().As<ICalculateRule>();
            builder.RegisterType<NameStartsWithADiscount>().As<INameStartsWithADiscount>();
        }
    }
}