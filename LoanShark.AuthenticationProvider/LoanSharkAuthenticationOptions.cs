using Microsoft.Owin.Security;

namespace LoanShark.AuthenticationProvider
{
    public class LoanSharkAuthenticationOptions : AuthenticationOptions
    {
        public LoanSharkAuthenticationOptions()
            : base("LoanShark")
        {
            AuthenticationMode = AuthenticationMode.Passive;
            Description.Caption = "LoanShark";
        }
    }
}
