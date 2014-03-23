using LoanShark.Core;
using LoanShark.Core.Collections.Data;

namespace LoanShark.Infrastructure.Collections.Repositories
{
    public class DebtRepository : EventSourcedRepository, IDebtRepository
    {
        public DebtRepository(IEventStore eventStore)
            : base(eventStore)
        {
            eventStore.ConnectionStringName = "collections";
        }
    }
}
