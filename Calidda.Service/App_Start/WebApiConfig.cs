using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Calidda.Service
{
    public static class WebApiConfig
    {
        public static HttpConfiguration Register()
        {
            var config = new HttpConfiguration();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
            config.MapHttpAttributeRoutes();

            var cors = new EnableCorsAttribute("*", "*", "*");
            cors.ExposedHeaders.Add("X-Pagination");
            config.EnableCors(cors);

            config.Routes.MapHttpRoute(
                          name: "DefaultApi",
                          routeTemplate: "api/{controller}/{id}",
                          defaults: new { id = RouteParameter.Optional }
                      );
            return config;
        }
    }
}
