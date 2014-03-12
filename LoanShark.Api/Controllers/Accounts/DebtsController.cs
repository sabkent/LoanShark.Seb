using System.Net.Http;
using LoanShark.Api.Representations.Accounts;
using System;
using System.Collections.Generic;
using System.Web.Http;
using LoanShark.Core;

namespace LoanShark.Api.Controllers.Accounts
{
    public class DebtsController : ApiController
    {
        private readonly IReadModelRepository _readModelRepository;

        public DebtsController(IReadModelRepository readModelRepository)
        {
            _readModelRepository = readModelRepository;
        }


        public IEnumerable<Debt> Get()
        {
            return new List<Debt>
            {
                new Debt{Amount = 100, DueDate = DateTime.Now.AddDays(15), Id = Guid.NewGuid()},
                new Debt{Amount = 30, DueDate = DateTime.Now.AddDays(1), Id = Guid.NewGuid()}
            };
        }

        public HttpResponseMessage Post()
        {
            var response = Request.CreateResponse();



            return response;
        }
    }
}
