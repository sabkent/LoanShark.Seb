using System;

namespace LoanShark.Core.Origination.Domain.Events
{
    public sealed class ApplicationCreated : IEvent
    {
        public ApplicationCreated(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }
}
