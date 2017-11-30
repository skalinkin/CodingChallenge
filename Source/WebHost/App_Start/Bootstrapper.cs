using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using CodingChallengeApplication;
using CodingChallengeApplication.LiteDbModule;

namespace WebHost
{
    public class Bootstrapper
    {
        public static void AutofacIntegration()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule<CodingChallengeModule>();
            builder.RegisterModule<LiteDbModule>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}