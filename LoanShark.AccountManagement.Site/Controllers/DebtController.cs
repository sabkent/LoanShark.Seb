using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using LoanShark.AccountManagement.Site.ViewModels;
using LoanShark.AuthenticationProvider;

namespace LoanShark.AccountManagement.Site.Controllers
{
    public class DebtController : Controller
    {
        //
        // GET: /Debt/
        public async Task<ActionResult> Index()
        {
            var authClient = new OAuthClient(new Uri("http://localhost:11754/api/token"));

            var token = await authClient.RequestResourceOwnerPasswordAsync("seb", "bob");

            List<Debt> debts = null;
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
                
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