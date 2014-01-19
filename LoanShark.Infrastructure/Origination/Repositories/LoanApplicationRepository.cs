using LoanShark.Core;
using LoanShark.Core.Origination.Data;

namespace LoanShark.Infrastructure.Origination.Repositories
{
    public class LoanApplicationRepository : EventSourcedRepository, ILoanApplicationRepository
    {
        public LoanApplicationRepository(IEventStore eventStore)
            : base(eventStore)
        {
            eventStore.ConnectionStringName = "origination";
        }
    }
}
