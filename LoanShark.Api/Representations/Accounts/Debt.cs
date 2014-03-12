using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanShark.Api.Representations.Accounts
{
    public class Debt 
    {
        public Guid Id { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
    }
}