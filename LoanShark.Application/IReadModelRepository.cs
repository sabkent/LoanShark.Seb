
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LoanShark.Application
{
    public interface IReadModelRepository
    {
        IEnumerable<T> GetAll<T>(Expression<Func<T, bool>> query);
        void Save<T>(T projection);
    }
}
