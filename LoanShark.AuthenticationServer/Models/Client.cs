using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace LoanShark.AuthenticationServer.Models
{
    public class Client
    {
        public string Identifier { get; set; }
        public string CertificateSubject { get; set; }
    }
}