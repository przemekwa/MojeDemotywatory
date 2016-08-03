using System.Web.Http;

namespace MojeDemotywatory
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "PageRangeApi",
                routeTemplate: "api/page/{first}-{last}",
                defaults: new { controller = "DemotivatorApi" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/page/{id}",
                defaults: new { controller = "DemotivatorApi", id = RouteParameter.Optional }
            );
        }
    }
}
