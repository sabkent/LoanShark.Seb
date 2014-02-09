using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoanShark.Application.Origination.Events;
using LoanShark.Messaging.ClientSide;
using Microsoft.AspNet.SignalR;

namespace LoanShark.Origination.Site.Controllers.Api
{
    public class EventController : ApiController
    {
        //private readonly IConnectionManager _connectionManager;

        //public EventController(IConnectionManager connectionManager)
        //{
        //    _connectionManager = connectionManager;
        //}

        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("api/event/loan-application-accepted"), HttpPost]
        public void Post(LoanApplicationAccepted loanApplicationAccepted)
        {
            //var hub = GlobalHost.ConnectionManager.GetHubContext<LoanShark.Origination.Site.Hubs.LoanApplication>();
            //var connectionManager = GlobalHost.DependencyResolver.GetService(typeof (IConnectionManager)) as IConnectionManager;
            //var hub = _connectionManager.GetHubContext<LoanApplicationHub>();

            //var hub = GlobalHost.ConnectionManager.GetHubContext<LoanApplicationHub>();
            var hub = GlobalHost.ConnectionManager.GetHubContext<LoanApplicationsHub>();
            //hub.Clients.All.complete();
            hub.Clients.All.complete();
        }

        [Route("api/event/loan-application-rejected"), HttpPost]
        public void Post()
        {
            
        }
    }
}