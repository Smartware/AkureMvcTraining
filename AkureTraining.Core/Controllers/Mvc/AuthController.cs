using AkureTraining.Core.Context;
using AkureTraining.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using Microsoft.Owin.Security;

namespace AkureTraining.Core.Controllers.Mvc
{
    [AllowAnonymous]
    public class AuthController : BaseMvcController
    {
        public AuthController()
        {
           
        }

        public ActionResult Logout()
        {
            var ctxt = Request.GetOwinContext();
            var _authMgr = ctxt.Authentication;

            _authMgr.SignOut("DefaultAuthentication");

            return Redirect("~/Auth/Login");
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginVM, String ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
           
            var identity = new ClaimsIdentity("DefaultAuthentication");
            identity.AddClaim(new Claim(ClaimTypes.Name, "Prolifik lexzy"));
            identity.AddClaim(new Claim(ClaimTypes.Email, loginVM.Username));
            identity.AddClaim(new Claim(ClaimTypes.Country, "Ondo State"));

            var ctxt = Request.GetOwinContext();
            var _authMgr = ctxt.Authentication;

            _authMgr.SignIn(identity);
            return Redirect("~/Home/Index");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
    }
}
