using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace LoanShark.AuthenticationProvider
{
    public class TokenResponse
    {
        public JObject Json { get; protected set; }

        public TokenResponse(string raw)
        {
            Json = JObject.Parse(raw);
        }

        public string AccessToken
        {
            get
            {
                var value = Json["access_token"];
                return value != null ? value.ToString() : null;
            }
        }

        public bool IsValid()
        {
            return true;
        }
    }
}
