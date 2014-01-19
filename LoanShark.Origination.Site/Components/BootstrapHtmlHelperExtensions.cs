using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace LoanShark.Origination.Site.Components
{
    public static class BootstrapHtmlHelperExtensions
    {
        public static MvcHtmlString FormGroupFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> modelExpression )
        {
            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass("form-group");
            tagBuilder.InnerHtml = htmlHelper.LabelFor(modelExpression, new { @class = "control-label col-md-2" }).ToHtmlString();

            var innerDiv = new TagBuilder("div");
            innerDiv.AddCssClass("col-md-10");

            innerDiv.InnerHtml = htmlHelper.EditorFor(modelExpression).ToHtmlString();
            innerDiv.InnerHtml += htmlHelper.ValidationMessageFor(modelExpression);
            tagBuilder.InnerHtml += innerDiv.ToString();

            return MvcHtmlString.Create(tagBuilder.ToString());
        }
    }
}