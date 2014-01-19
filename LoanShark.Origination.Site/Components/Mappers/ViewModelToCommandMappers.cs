using System;
using LoanShark.Application;
using AutoMapper;
using LoanShark.Core;
using LoanShark.Origination.Site.ViewModels;
using LoanShark.Core.Origination.Commands;

namespace LoanShark.Origination.Site.Components.Mappers
{
    public sealed class ViewModelToCommandMappers : IBootstrapTask
    {
        public void Run()
        {
            Mapper.CreateMap<LoanApplication, ApplyForLoan>()
                .ForMember(applyForLoan => applyForLoan.Id, opt => opt.MapFrom(src => SecureIdGenerator.NewGuid()));
        }
    }
}