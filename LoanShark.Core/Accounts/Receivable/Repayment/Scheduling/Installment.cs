﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanShark.Core.Accounts.Receivable.Repayment.Scheduling
{
    public class Installment
    {
        public decimal Amount { get; set; }
        public DateTime Due { get; set; }
    }
}
