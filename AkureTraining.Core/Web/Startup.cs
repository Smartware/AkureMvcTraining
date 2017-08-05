using AkureTraining.Core.Web;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(Startup), "Setup")]
namespace AkureTraining.Core.Web
{
    public partial class Startup
    {
        public static void Setup(IAppBuilder app)
        {
            ConfigureAuth(app);

            HttpConfiguration apiConfig = new HttpConfiguration();
            ConfigureComposition(apiConfig);
        }
    }
}
