using System.Net.Http.Headers;
using System.Web.Http;

namespace CityWeather
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //by default, return only Json
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            // no XML
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //specific message for 404
            config.MessageHandlers.Add(new NotFoundHandler());


        }

    }
}
