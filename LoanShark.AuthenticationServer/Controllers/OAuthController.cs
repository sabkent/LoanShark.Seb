//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using LoanShark.AuthenticationServer.Infrastructure;
//using DotNetOpenAuth.OAuth2;
//using LoanShark.AuthenticationServer.Models;

//namespace LoanShark.AuthenticationServer.Controllers
//{
//    public class OAuthController : Controller
//    {
//        private readonly AuthorizationServer _authorizationServer = new AuthorizationServer(new ServerHost());

//        private ClientRepository _clientRepository;

//        public ActionResult Index()
//        {
//            var request = _authorizationServer.ReadAuthorizationRequest();
//            if (request == null)
//                throw new HttpException((int)HttpStatusCode.BadRequest, "Bad request");

//            var client = _clientRepository.GetById(request.ClientIdentifier);

//            var authenticationViewModel = new AuthenticationViewModel
//            {
//                Scope = request.Scope,
//                Request = request
//            };

//            return View(authenticationViewModel);
//        }

//        [HttpPost]
//        public ActionResult Index(string url)
//        {
//            return View();
//        }
//    }
//}