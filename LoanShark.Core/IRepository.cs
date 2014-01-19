using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanShark.Core
{
    public interface IRepository
    {
        T GetById<T>(Guid id) where T : Aggregate;
        void Save(Aggregate aggregate);
    }
}
