using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanShark.Api.Representations.Originations
{
    public class LoanApplication
    {
        public string FirstName { get; set; }
        public decimal Amount { get; set; }
    }
}