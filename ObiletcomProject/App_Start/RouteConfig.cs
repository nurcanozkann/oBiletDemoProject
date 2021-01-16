using System.Web.Mvc;
using System.Web.Routing;

namespace ObiletcomProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "SeferlerIndex",
                url: "{controller}/{action}/{originId}-{destinationId}/{departuredate}",
                defaults: new { controller = "Journey", action = "Index" }
            );

            routes.MapRoute(
                name: "SeferlerDetay",
                url: "{controller}/{action}/{originId}-{destinationId}/{departuredate}/{journeyid}",
                defaults: new { controller = "Journey", action = "JourneyDetail" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}