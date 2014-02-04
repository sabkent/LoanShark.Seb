using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoanShark.Api.Controllers.Banking
{
    public class CardsController : ApiController
    {
        public HttpResponseMessage Post()
        {
            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}
