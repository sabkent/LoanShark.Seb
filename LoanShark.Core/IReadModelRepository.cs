using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LoanShark.Core
{
    public interface IReadModelRepository
    {
        IEnumerable<T> GetAll<T>(Expression<Func<T, bool>> query);
        void Save<T>(T projection);
        void Remove<T>(Expression<Func<T, bool>> query);
    }
}
