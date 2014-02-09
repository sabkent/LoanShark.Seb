using LoanShark.Api.Representations.Accounts;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace LoanShark.Api.Controllers.Accounts
{
    public class DebtsController : ApiController
    {
        public IEnumerable<Debt> Get()
        {
            return new List<Debt>
            {
                new Debt{Amount = 100, DueDate = DateTime.Now.AddDays(15), Id = Guid.NewGuid()},
                new Debt{Amount = 30, DueDate = DateTime.Now.AddDays(1), Id = Guid.NewGuid()}
            };
        }
    }
}
