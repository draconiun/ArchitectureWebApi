//using Calidda.Service.App_Start;
using Microsoft.Owin;
using Owin;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(Calidda.Service.Startup))]

namespace Calidda.Service
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = WebApiConfig.Register();

            app.UseWebApi(config);
            config.EnableSwagger(c => c.SingleApiVersion("V1", "Calidda Web API")).EnableSwaggerUi();
            AutofacConfig.Register(config, app);
            AutoMapperConfig.Initialize();
        }
    }
}