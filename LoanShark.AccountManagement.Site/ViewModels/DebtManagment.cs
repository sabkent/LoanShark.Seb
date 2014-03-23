using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanShark.AccountManagement.Site.ViewModels
{
    public class DebtManagment
    {
        public IEnumerable<CurrentDebt> Debts { get; set; }

    }
}