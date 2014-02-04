using LoanShark.Banking.Site.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanShark.Banking.Site.Controllers
{
    public class CardController : Controller
    {
        //
        // GET: /Card/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CreateCard createCard)
        {
            return Redirect(Url.Action("Complete") + "#message");
        }

        public ActionResult Complete()
        {
            return View();
        }
	}
}