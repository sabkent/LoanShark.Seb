
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using LoanShark.UI.Representations;

namespace LoanShark.AccountManagement.Site.Controllers
{
    using Api;
    using Api.Representations;
    using ViewModels;

    public class DebtController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var apiProxy = new ApiProxy();

            //await apiProxy.Post("debts", new Debt
            //{
            //    Amount = 100,
            //    DueDate = DateTime.Now.AddMonths(1),
            //    Id = Guid.NewGuid()
            //});

            var debts = await apiProxy.Get<List<Debt>>("debts");

            var currentDebts = debts.ConvertAll(debt => new CurrentDebt
            {
                Amount = debt.Amount,
                DueDate = debt.DueDate,
                Id = debt.Id,
                Links = new List<ResourceLink>
                {
                    new ResourceLink
                    {
                        Id = new Uri(String.Format("http://accountmanagement.localhost/api/debts/{0}", debt.Id)),
                        Name = "Make Payment"
                    }
                }
            });

            return View(new DebtManagment
            {
                Debts = currentDebts
            });
        }

        //public ActionResult Index(Guid id)
        //{
        //    return View();
        //}
	}
}