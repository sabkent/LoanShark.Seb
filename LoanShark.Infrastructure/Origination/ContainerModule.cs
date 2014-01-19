using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanShark.Core.Origination.Data;
using LoanShark.Infrastructure.Origination.Repositories;

namespace LoanShark.Infrastructure.Origination
{
    public class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterRepositories(builder);
        }

        private void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<LoanApplicationRepository>().As<ILoanApplicationRepository>();
        }
    }
}
