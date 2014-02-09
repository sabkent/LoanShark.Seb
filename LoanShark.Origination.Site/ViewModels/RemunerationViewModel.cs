using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanShark.Origination.Site.ViewModels
{
    public class RemunerationViewModel
    {
        public DateTime NextPayDate { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

    }
}