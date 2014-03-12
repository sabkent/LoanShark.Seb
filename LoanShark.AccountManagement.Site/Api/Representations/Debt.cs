using LoanShark.UI.Representations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanShark.AccountManagement.Site.Api.Representations
{
    public class Debt : Representation
    {
        public Guid Id { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
    }
}