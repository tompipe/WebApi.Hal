using System.Configuration;
using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Newtonsoft.Json;
using WebApi.Hal.Web.App_Start;
using WebApi.Hal.Web.Data;
using WebApi.Hal.Web.Migrations;

namespace WebApi.Hal.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        IContainer container;

        protected void Application_Start()
        {
            RouteConfig.RegisterRoutes(GlobalConfiguration.Configuration.Routes);

            GlobalConfiguration.Configuration.Formatters.Add(new JsonHalMediaTypeFormatter());
            GlobalConfiguration.Configuration.Formatters.Add(new XmlHalMediaTypeFormatter());

            var containerBuilder = new ContainerBuilder();

            ConfigureContainer(containerBuilder);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BeerDbContext, BeerDbContextConfiguration>());

            container = containerBuilder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        }

        private void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            // Register API controllers using assembly scanning.
            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            containerBuilder
                .Register(c=> new BeerDbContext())
                .As<IBeerDbContext>()
                .InstancePerApiRequest();

            containerBuilder
                .RegisterType<BeerRepository>()
                .As<IRepository>()
                .InstancePerApiRequest();
        }
    }
}