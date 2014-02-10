using LoanShark.Core;
using System.Web.Mvc;

namespace LoanShark.Origination.Site.Components
{
    public static class ControllerCommandExtensions
    {
        public static CommandActionResult<TModel, TCommand> ExecuteCommand<TModel, TCommand>(this Controller controller, TModel model) 
            where TCommand : class, ICommand
        {
            return new CommandActionResult<TModel, TCommand>(model);
        }
    }
}