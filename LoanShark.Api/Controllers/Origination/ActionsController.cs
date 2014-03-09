using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoanShark.Api.Controllers.Origination
{
    public class ActionsController : ApiController
    {
        [Route("{type}/success"), HttpPost]
        public HttpResponseMessage PostSuccessEvent()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
