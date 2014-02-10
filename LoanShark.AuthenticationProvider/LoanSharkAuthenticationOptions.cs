using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanShark.AuthenticationProvider
{
    public class LoanSharkAuthenticationOptions : AuthenticationOptions
    {
        public LoanSharkAuthenticationOptions()
            : base("LoanShark")
        {
            
        }
    }
}
