using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace LoanShark.Core
{
    public interface IEventStore
    {
        void StoreEvents(Guid streamId, IEnumerable<IEvent> events, long expectedVersion);
        IEnumerable<IEvent> LoadEvents(Guid id, long version = 0);

        //TODO: GLUDGEMUFFIN: multi bounded context issue
        string ConnectionStringName { set; }
    }
}
