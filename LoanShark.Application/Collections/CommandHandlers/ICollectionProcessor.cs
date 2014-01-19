using System.Collections.Generic;
using LoanShark.Core.Collections.Domain;

namespace LoanShark.Application.Collections.CommandHandlers
{
    public interface ICollectionProcessor
    {
        IEnumerable<CollectionAttempt> Process(IEnumerable<OutstandingDebt> outstandingDebts);
    }
}