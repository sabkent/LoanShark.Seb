using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetOpenAuth.OAuth2.Messages;

namespace LoanShark.AuthenticationServer.Models
{
    public class AuthenticationViewModel
    {
        public HashSet<string> Scope { get; set; }
        public EndUserAuthorizationRequest Request { get; set; }
    }
}