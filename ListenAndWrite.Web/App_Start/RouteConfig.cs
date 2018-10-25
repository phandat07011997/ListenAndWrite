using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ListenAndWrite.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Choose",
                url: "Audio/Choose/{id}",
                defaults: new { controller = "Audio", action = "Choose", id = UrlParameter.Optional },
                namespaces: new string[] { "ListenAndWrite.Web.Controllers" }
            );
            //routes.MapRoute(
            //    name: "Level",
            //    url: "audio/level/{level}",
            //    defaults: new { controller = "Home", action = "Index", level = UrlParameter.Optional },
            //    namespaces: new string[] { "ListenAndWrite.Web.Controllers" }
            //);
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{level}",
                defaults: new { controller = "Home", action = "Index", level = UrlParameter.Optional },
                namespaces: new string[] { "ListenAndWrite.Web.Controllers" }
            );
        }
    }
}
