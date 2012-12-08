using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Newtonsoft.Json.Serialization;
using WebApiContrib.Formatting;

namespace TodoWebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Formatters.Add(new ProtoBufFormatter());

            var builder = new ContainerBuilder();
            
            var webApiAssembly = Assembly.Load("Todo.WebApi");
            builder.RegisterApiControllers(webApiAssembly);

            var assembly = Assembly.Load("Todo.DataAccess");
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerApiRequest();

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            config.DependencyResolver = resolver;
        }
    }
}
