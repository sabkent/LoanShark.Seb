using System.ComponentModel.DataAnnotations;

namespace LoanShark.Origination.Site.ViewModels
{
    public class LoanApplication
    {
        [Required(ErrorMessageResourceType  = typeof(ValidationMessages), ErrorMessageResourceName ="LoanApplication_FirstName_Required")]
        [Display(ResourceType = typeof(TitlesAndLabels), Name = "LoanApplication_FirstName")]
        public string FirstName { get; set; }
        public decimal Amount { get; set; }

        public RemunerationViewModel Remuneration { get; set; }
    }
}