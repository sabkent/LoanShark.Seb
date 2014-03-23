using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanShark.AccountManagement.Site.ViewModels
{
    public class CurrentDebt
    {
        public Guid Id { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }

        public IEnumerable<ResourceLink> Links { get;  set; }
    }
}