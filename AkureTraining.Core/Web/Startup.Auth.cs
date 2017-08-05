using Owin;
using Microsoft.Owin.Security.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace AkureTraining.Core.Web
{
    public partial class Startup
    {
        public static void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                LoginPath = new PathString("/Auth/Login"),
                LogoutPath = new PathString("/Auth/Logout"),
                CookieName = "AkureTraining",
                AuthenticationType = "DefaultAuthentication",
                AuthenticationMode = AuthenticationMode.Active,
                ReturnUrlParameter = "ReturnUrl"
            });
        }
    }
}
