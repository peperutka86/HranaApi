using Autofac;
using Autofac.Integration.WebApi;

using HranaLibrary.Repository;
using HranaLibrary.Services;
using log4net;
using System.Reflection;
using System.Web.Http;




namespace HranaApi
{

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            #region DI configuration
            // DI
            var builder = new ContainerBuilder();

            // Register all dependencies here
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.Register(c => LogManager.GetLogger(typeof(object))).As<ILog>();
            builder.RegisterType<DataRepo>().As<IDataRepo>();
            builder.RegisterType<RecipeService>().As<IRecipeService1>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            #endregion


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}