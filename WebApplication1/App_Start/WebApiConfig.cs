﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace WebApplication1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

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
        }
    }
}
