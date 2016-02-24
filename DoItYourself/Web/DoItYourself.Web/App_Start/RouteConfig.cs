namespace DoItYourself.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*routes.MapRoute(
                name: "Projects",
                url: "Projects/{action}",
                defaults: new { controller = "Projects" });*/

            routes.MapRoute(
                name: "StaticPages",
                url: "{action}",
                defaults: new { controller = "Home" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Home", id = UrlParameter.Optional });
        }
    }
}
