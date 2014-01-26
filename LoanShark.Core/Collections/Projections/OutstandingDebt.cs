using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanShark.Core.Collections.Projections
{
    public class OutstandingDebt
    {
        public Guid Id { get; set; }
        public DateTime Due { get; set; }
        public decimal Amount { get; set; }
    }
}
