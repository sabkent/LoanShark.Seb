using System.Net.Http;
using System.Threading.Tasks;
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
            return _readModelRepository.GetAll<Debt>(debt => debt.DueDate > DateTime.Now);
            //return new List<Debt>
            //{
            //    new Debt{Amount = 100, DueDate = DateTime.Now.AddDays(15), Id = Guid.NewGuid()},
            //    new Debt{Amount = 30, DueDate = DateTime.Now.AddDays(1), Id = Guid.NewGuid()}
            //};
        }

        public async Task<HttpResponseMessage> Post()
        {
            var response = Request.CreateResponse();

            var debt = await Request.Content.ReadAsAsync<Debt>();

            _readModelRepository.Save(debt);

            return response;
        }
    }
}
