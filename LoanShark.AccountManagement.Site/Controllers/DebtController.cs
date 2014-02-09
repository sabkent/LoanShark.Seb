using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using LoanShark.AccountManagement.Site.ViewModels;

namespace LoanShark.AccountManagement.Site.Controllers
{
    public class DebtController : Controller
    {
        //
        // GET: /Debt/
        public ActionResult Index()
        {
            List<Debt> debts = null;
            using (var httpClient = new HttpClient())
            {
                //httpClient.BaseAddress = new Uri("http://localhost:12274/api/debts");

                var response = httpClient.GetAsync("http://localhost:12274/api/debts").Result;

                debts = response.Content.ReadAsAsync<List<Debt>>().Result;
            }
            return View(debts ?? new List<Debt>());
        }

        //public ActionResult Index(Guid id)
        //{
        //    return View();
        //}
	}
}