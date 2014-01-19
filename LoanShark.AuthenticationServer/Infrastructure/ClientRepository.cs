using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoanShark.AuthenticationServer.Models;

namespace LoanShark.AuthenticationServer.Infrastructure
{
    public class ClientRepository
    {
        public Client GetById(string id)
        {
            return new Client();
        }
    }
}