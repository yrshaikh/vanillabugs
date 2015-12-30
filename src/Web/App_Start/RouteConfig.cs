using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "SigIn",
                url: "sign-in",
                defaults: new { controller = "Account", action = "SignIn", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "SigUp",
                url: "sign-up",
                defaults: new { controller = "Account", action = "SignUp", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
