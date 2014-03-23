using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanShark.Core.Collections.Domain
{
    public class Interest
    {
        public void Calculate()
        {
            double principal, annualRate, interest;
            double futureValue, ratePerPeriod;


            principal = 100;
            annualRate = 1400;
            
            int compoundType = 12; //monthly, 1 for yearly, 4 quarterly
            int periods = 6;

            double i = annualRate/compoundType;
            int n = compoundType*periods;

            ratePerPeriod = annualRate/periods;
            futureValue = principal*Math.Pow(1 + i, n);
            interest = futureValue - principal;
        }
    }
}
