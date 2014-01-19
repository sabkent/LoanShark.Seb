using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LoanShark.Application.Messaging;
using LoanShark.Core;

namespace LoanShark.Origination.Site.Components
{
    public class CommandActionResult<TModel, TCommand> : ActionResult where TCommand : class, ICommand
    {
         private readonly TModel _model;
        private Func<ICommand, ActionResult> _successAction;
        private readonly ICommandValidation _commandValidation;
        private readonly ICommandDispatcher _commandDispatcher;

        public CommandActionResult(TModel model)
        {
            _model = model;

            //TODO: this is framework code so service location is ok, but not great.
            _commandValidation = DependencyResolver.Current.GetService<ICommandValidation>();
            _commandDispatcher = DependencyResolver.Current.GetService<ICommandDispatcher>();
        }

        public ActionResult Success(Func<ICommand, ActionResult> successAction)
        {
            _successAction = successAction;
            return this;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var command = Mapper.Map<TCommand>(_model);
            var validationErrors = _commandValidation.Validate(command).ToList();

            if (validationErrors.Any())
            {
                var view = new ViewResult();
                view.ViewData.Model = context.Controller.ViewData.Model;
                validationErrors.ForEach(error => view.ViewData.ModelState.AddModelError(error.Key, error.Message));
                view.ExecuteResult(context);
                return;
            }

            _commandDispatcher.Send(command);

            if(_successAction != null)
                _successAction(command).ExecuteResult(context);
        }
    }
}