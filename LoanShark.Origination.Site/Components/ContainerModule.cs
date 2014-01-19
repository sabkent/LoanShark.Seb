using Autofac;
using FluentValidation;
using LoanShark.Application;
using LoanShark.Origination.Site.Components.Mappers;
using LoanShark.Origination.Site.Components.Validators;
using LoanShark.Origination.Site.ViewModels;

namespace LoanShark.Origination.Site.Components
{
    public class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterBootstrapTasks(builder);
            builder.RegisterType<LoanApplicationValidation>().As<IValidator<LoanApplication>>();
        }

        private void RegisterBootstrapTasks(ContainerBuilder builder)
        {
            builder.RegisterType<SignalRBootstrapTask>().As<IBootstrapTask>();
            builder.RegisterType<DependencyResolverBootstrapTask>().As<IBootstrapTask>();
            builder.RegisterType<ViewModelToCommandMappers>().As<IBootstrapTask>();
        }
    }
}