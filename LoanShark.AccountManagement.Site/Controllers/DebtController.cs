using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using LoanShark.AccountManagement.Site.Api;
using LoanShark.AccountManagement.Site.ViewModels;
using LoanShark.AuthenticationProvider;
using LoanShark.AccountManagement.Site.Api.Representations;

namespace LoanShark.AccountManagement.Site.Controllers
{
    public class DebtController : Controller
    {
        //
        // GET: /Debt/
        public async Task<ActionResult> Index()
        {
            List<Debt> debts = null;

            //var apiProxy = new ApiProxy();
            //debts = await apiProxy.Get<List<Debt>>("/debts");
            //debts = await new ApiProxy().Get<List<Debt>>("/debts");




            var authClient = new OAuthClient(new Uri("http://localhost:11754/api/token"));

            var token = await authClient.RequestResourceOwnerPasswordAsync("seb", "bob");


            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);

                //httpClient.BaseAddress = new Uri("http://localhost:12274/api/debts");

                var response = await httpClient.GetAsync("http://localhost:12274/api/debts");

                debts = response.Content.ReadAsAsync<List<Debt>>().Result;
            }


            return View(new List<CurrentDebt>());
        }

        //public ActionResult Index(Guid id)
        //{
        //    return View();
        //}
	}
}