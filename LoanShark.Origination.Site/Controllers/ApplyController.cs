using AutoMapper;
using LoanShark.Application.Messaging;
using LoanShark.Core;
using LoanShark.Core.Origination.Commands;
using LoanShark.Origination.Site.Components;
using LoanShark.Origination.Site.Components.Validators;
using LoanShark.Origination.Site.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace LoanShark.Origination.Site.Controllers
{
    public class ApplyController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly ICommandValidation _commandValidation;
        private readonly IReadModelRepository _readModelRepository;

        public ApplyController(ICommandDispatcher commandDispatcher, ICommandValidation commandValidation, IReadModelRepository readModelRepository)
        {
            _commandDispatcher = commandDispatcher;
            _commandValidation = commandValidation;
            _readModelRepository = readModelRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult _Index(LoanApplication loanApplication)
        {
            var applyForLoan = Mapper.Map<LoanApplication, ApplyForLoan>(loanApplication);
            var validationErrors = _commandValidation.Validate(applyForLoan);

            if (validationErrors.Any())
            {
                validationErrors.ToList().ForEach(error=>ModelState.AddModelError(error.Key, error.Message));
                //return View();
            }

            _commandDispatcher.Send(applyForLoan);
            return RedirectToAction("Processing", new{applyForLoan.Id});
        }

        [HttpPost]
        public ActionResult Index(LoanApplication loanApplication)
        {
            loanApplication.FirstName = null;
            //TODO: extension method doesn't work without 'this' qualifier, peculiar!
            return this.ExecuteCommand<LoanApplication, ApplyForLoan>(loanApplication)
                .Success(command => RedirectToAction("Processing", new {command.Id}));
        }

        public ActionResult Processing(Guid id)
        {
            return View();
        }

        public ActionResult Complete(Guid id)
        {
            return View();
        }

        public JsonResult ValidateFromClient(LoanApplication loanApplication)
        {
            var result = Validate(loanApplication);

            return Json(result);
        }

        private FluentValidation.Results.ValidationResult Validate(LoanApplication loanApplication)
        {
            return new LoanApplicationValidation().Validate(loanApplication);
        }
	}
}