using LoanShark.Application.Messaging;
using LoanShark.Application.Origination.Events;
using LoanShark.Core;
using LoanShark.Core.Origination.Commands;
using LoanShark.Core.Origination.Data;
using LoanShark.Core.Origination.Domain;

namespace LoanShark.Application.Origination.CommandHandlers
{
    public sealed class ApplyForLoanHandler : IHandleCommand<ApplyForLoan>
    {
        private readonly ILoanApplicationRepository _loanApplicationRepository;
        private readonly IEventPublisher _eventPublisher;

        public ApplyForLoanHandler(ILoanApplicationRepository loanApplicationRepository, IEventPublisher eventPublisher)
        {
            _loanApplicationRepository = loanApplicationRepository;
            _eventPublisher = eventPublisher;
        }

        public void Handle(ApplyForLoan applyForLoan)
        {
            var application = new LoanApplication(applyForLoan.Id)
            {
                Applicant = new Applicant()
            };

            //var events = application.Process();  //return LoanAccept| loanRejected plus LoanEnteredIntoTrialX

            _loanApplicationRepository.Save(application);
            
            _eventPublisher.Publish(new LoanApplicationAccepted(application.Id, application.Applicant.Id, applyForLoan.Amount));
        }
    }
}
