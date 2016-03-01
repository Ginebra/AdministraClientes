using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebService
{
    public static class WebApiConfig
    {
      

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}&{nombre}",
                defaults: new { id = RouteParameter.Optional, nombre = RouteParameter.Optional}
            );

            config.Routes.MapHttpRoute(
              "AccesoCliente",
              "Api/Clientes/Cliente/{id}&{nombre}",
              new
              {
                  controller = "Clientes",
                  action = "Cliente",
                  id = RouteParameter.Optional,
                  nombre = RouteParameter.Optional
              });

            config.Routes.MapHttpRoute(
                "AccesoClientes",
                "Api/Clientes",
                new
                {
                    controller = "Clientes",
                    action = "Clientes"
                }
            );

            config.Routes.MapHttpRoute(
                "Api_default",
                "Api/{controller}/{action}/{id}&{nombre}",
                new
                {
                    action = "Index",
                    id = RouteParameter.Optional,
                    nombre = RouteParameter.Optional
                }
            );
        }
    }
}
