using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace MujZavod.Admin.Helpers
{
    public static class ViewExtensions
    {
       

        public static MvcHtmlString DivFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            var valueGetter = expression.Compile();
            var value = valueGetter(helper.ViewData.Model);

            var span = new TagBuilder("div");
            span.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            if (value != null)
            {
                span.SetInnerText(value.ToString());
            }

            return MvcHtmlString.Create(span.ToString());
        }

        public static MvcHtmlString LabelValueRowFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression,int labelWidth,int valueWidth,string ValueLinkHref=null)
        {
            string sValue;
            var valueGetter = expression.Compile();
            var value = valueGetter(helper.ViewData.Model);

            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();

            if (value == null)
                sValue = "?";
            else if (typeof(Models.PartialLinkedUserbasics)==metadata.ModelType)
            {
                Models.PartialLinkedUserbasics vm = (Models.PartialLinkedUserbasics)(object)value;
                sValue = helper.Partial("~/Views/Account/Partial/LinkedUserBasics.cshtml", vm).ToHtmlString();
            }
            else
            {
                sValue = value.ToString();
            }

            if (ValueLinkHref != null)
                sValue = "<a href=\"" + ValueLinkHref + "\">" + sValue + "</a>";




            return MvcHtmlString.Create("<div><label class=\"col-md-"+ labelWidth + " control-label\">" + labelText + "</label><div class=\"col-md-"+valueWidth+"\"><div class=\"form-control-static\">" + sValue + "</div></div></div>");
        }











        

    }
}