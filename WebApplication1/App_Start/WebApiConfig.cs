using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApplication1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApiWithId", 
            //    routeTemplate: "Api/{controller}/{id}", 
            //    defaults: new { id = RouteParameter.Optional }, new { id = @"\d+" });

            //config.Routes.MapHttpRoute(
            //    name: "Position2Api",
            //    routeTemplate: "api/Position2/{id}",
            //    defaults: new { controller = new string[] { "Position2" , "Login" }, id = RouteParameter.Optional }
            //);
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.MessageHandlers.Add(new AuthHandler());
        }
    }
}
