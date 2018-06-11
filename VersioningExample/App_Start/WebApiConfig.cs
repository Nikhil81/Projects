using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using VersioningExample.Models;

namespace VersioningExample
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

           // config.Routes.MapHttpRoute(
           //     name: "VersionV1",
           //     routeTemplate: "api/v1/students/{id}",
           //     defaults: new { id = RouteParameter.Optional, controller =  nameof(StudentV1) }
           // );

           // config.Routes.MapHttpRoute(
           //    name: "VersionV2",
           //    routeTemplate: "api/v2/students/{id}",
           //    defaults: new { id = RouteParameter.Optional, controller = nameof(StudentV2) }
           //);

        }
    }
}
