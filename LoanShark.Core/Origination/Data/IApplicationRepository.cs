using LoanShark.Core.Origination.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanShark.Core.Origination.Data
{
    public interface IApplicationRepository
    {
        void Add(LoanApplication application);
    }
}
