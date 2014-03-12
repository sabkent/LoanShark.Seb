
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

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

            await apiProxy.Post("debts", new Debt());

            List<Debt> debts = await apiProxy.Get<List<Debt>>("debts");

            var currentDebts = debts.ConvertAll(debt => new CurrentDebt
            {
                Amount = debt.Amount,
                DueDate = debt.DueDate,
                Id = debt.Id
            });

            return View(currentDebts);
        }

        //public ActionResult Index(Guid id)
        //{
        //    return View();
        //}
	}
}