using System;

namespace LoanShark.Application.Origination.Events
{
    public class LoanApplicationAccepted
    {
        public LoanApplicationAccepted(Guid applicationId, Guid applicantId, decimal amount)
        {
            ApplicationId = applicationId;
            ApplicantId = applicantId;
            Amount = amount;
        }
        public Guid ApplicationId { get; private set; }
        public Guid ApplicantId { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime DueDate { get; set; }
    }
}
