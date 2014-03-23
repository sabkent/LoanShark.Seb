using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanShark.Core.Collections.Commands
{
    public class ApplyInterestRate : ICommand
    {
        private readonly Guid _id;
        public ApplyInterestRate(Guid id)
        {
            _id = id;
        }

        public Guid Id
        {
            get { return _id; }
        }
    }
}
