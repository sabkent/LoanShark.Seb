using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoanShark.Api.Representations.Originations;
using LoanShark.Application.Messaging;
using LoanShark.Core.Origination.Commands;
using LoanShark.Messaging;

namespace LoanShark.Api.Controllers.Origination
{
    public class ApplicationController : ApiController
    {
        private readonly ICommandDispatcher _commandDispatcher;
        public ApplicationController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        public HttpResponseMessage Get(Guid applicationId)
        {
            var loanApplication = new LoanApplication();

            return Request.CreateResponse(HttpStatusCode.OK, loanApplication);
        }

        public HttpResponseMessage Post(LoanApplication loanApplication)
        {
            var submitApplication = new SubmitApplication();

            var response = Request.CreateResponse(HttpStatusCode.Accepted);

            response.Headers.Location = new Uri(String.Format("/application/{0}", submitApplication.Id));

            return response;
        }
    }
}
