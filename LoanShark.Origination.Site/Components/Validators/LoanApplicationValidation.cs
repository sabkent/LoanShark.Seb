using FluentValidation;
using LoanShark.Application;
using LoanShark.Origination.Site.ViewModels;

namespace LoanShark.Origination.Site.Components.Validators
{
    public class LoanApplicationValidation : AbstractValidator<LoanApplication>
    {
        public LoanApplicationValidation()
        {
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage(ValidationMessages.LoanApplication_Amount_GreaterThanZero);
        }

    }
}