using Autofac;
using Autofac.Integration.Mvc;
using CommandsHandlers.Match;
using CommandsValidators.Match;
using CQRSCore.Events;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DependencyConfig.RegisterDependencyResolvers();
        }
    }

    public static class DependencyConfig
    {
        public static IContainer RegisterDependencyResolvers()
        {
            ContainerBuilder builder = new ContainerBuilder();
            RegisterDependencyMappingDefaults(builder);
            RegisterDependencyMappingOverrides(builder);
            IContainer container = builder.Build();
            // Set Up MVC Dependency Resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            // Set Up WebAPI Resolver
            return container;
        }

        private static void RegisterDependencyMappingDefaults(ContainerBuilder builder)
        {
            Assembly webAssembly = Assembly.GetAssembly(typeof(MvcApplication));

            builder.RegisterAssemblyTypes(webAssembly).AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterControllers(webAssembly);
            builder.RegisterModule(new AutofacWebTypesModule());
        }

        private static void RegisterDependencyMappingOverrides(ContainerBuilder builder)
        {
            var assemblyType = typeof(EventBus).GetTypeInfo();
            var commandsHandlersAssemblyType = typeof(AddMatchCommandHandler).GetTypeInfo();
            var valdiatorsAssemblyType = typeof(AddMatchPlayersIdsValidator).GetTypeInfo();

            builder.RegisterAssemblyTypes(assemblyType.Assembly)
            .AsImplementedInterfaces()
            .InstancePerRequest();


            builder.RegisterAssemblyTypes(commandsHandlersAssemblyType.Assembly)
            .AsImplementedInterfaces()
            .InstancePerRequest();

            builder.RegisterAssemblyTypes(valdiatorsAssemblyType.Assembly)
                .AsImplementedInterfaces()
                .InstancePerRequest();
        }
    }

}
