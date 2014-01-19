using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LoanShark.AuthenticationServer.Controllers
{
    public class AuthenticateController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index(string userName, string password , string returnUrl)
        {
            bool isAuthentic = !String.IsNullOrWhiteSpace(userName) && userName.Equals(password);

            if (isAuthentic)
                FormsAuthentication.SetAuthCookie(userName, false);

            return Redirect(returnUrl ?? Url.Action("Index", "Home"));
        }
	}
}