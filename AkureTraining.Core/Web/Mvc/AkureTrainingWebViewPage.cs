using AkureTraining.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AkureTraining.Core.Web.Mvc
{

    public abstract class AkureTrainingWebViewPage<TModel> : WebViewPage<TModel> 
    {
        public String Country
        {
            get
            {
                ClaimsIdentity identities = User.Identity as ClaimsIdentity;
                var country = identities.FindFirst(ClaimTypes.Country)?.Value;

                if (String.IsNullOrEmpty(country))
                    return String.Empty;

                return country;
            }
        }

        public String Email
        {
            get
            {
                ClaimsIdentity identities = User.Identity as ClaimsIdentity;
                var email = identities.FindFirst(ClaimTypes.Email)?.Value;

                if (String.IsNullOrEmpty(email))
                    return String.Empty;

                return email;
            }
        }
    }
    public abstract class AkureTrainingWebViewPage : AkureTrainingWebViewPage<dynamic>
    {
       public String Testing { get; set; }
    }

   
}
