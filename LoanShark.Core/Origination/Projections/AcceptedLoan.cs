using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanShark.Core.Origination.Projections
{
    public class AcceptedLoan
    {
        public DateTime Requested { get; set; }
        public Guid ApplicationId { get; set; }
    }
}
