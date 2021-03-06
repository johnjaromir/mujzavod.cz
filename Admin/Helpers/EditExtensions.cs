﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace MujZavod.Admin.Helpers
{
    public static class EditExtensions
    {
        

        public static MvcHtmlString MzDatePickerFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            var id = htmlHelper.IdFor(expression);
            string script = "<script>$('#"+id+"').datepicker({format: 'dd.mm.yyyy',language:'cs'});</script>";
            return MvcHtmlString.Create(htmlHelper.MzTextBoxFor(expression, htmlAttributes).ToString() + script);
        }


        public static MvcHtmlString MzTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            
            return MvcHtmlString.Create(htmlHelper.TextBoxFor(expression, htmlAttributes).ToString() 
                + htmlHelper.ValidationMessageFor(expression, "", new { @class="text-danger" }));
        }

        public static MvcHtmlString MzDropDownFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, Models.DropDown.IDropDownModel dropDownModel, string optionLabel = null, object htmlAttributes = null)
        {
            return MvcHtmlString.Create(htmlHelper.DropDownListFor(expression, dropDownModel.items, optionLabel, htmlAttributes).ToString()
                //+ htmlHelper.HiddenFor(expression)
                + htmlHelper.ValidationMessageFor(expression, "", new { @class = "text-danger" }));
            
        }


        public static MvcHtmlString MzEditLineFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, 
            object htmlAttributes = null, string labelFormat = "col-sm-4", string editFormat = "col-sm-8", string editType = "text")
        {
            return MvcHtmlString.Create("<div class='form-group'>"
                + htmlHelper.LabelFor(expression, new { @class=labelFormat +" control-label" }).ToString()
                + "<div class='"+editFormat+"'>" + MzEditFor(htmlHelper, expression, new { @class="form-control", @type=editType }).ToString()
                + "</div></div>");
        }

        

        public static MvcHtmlString MzEditFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            Type t = metadata.ModelType;

            if (t == typeof(DateTime) || t == typeof(DateTime?))
                return MzDatePickerFor(htmlHelper, expression, htmlAttributes);
            /*else if (t == typeof(double) || t == typeof(double?))
                return MzTextBoxFor(htmlHelper, expression, new { type = "number" });*/
            else
                return MzTextBoxFor(htmlHelper, expression, htmlAttributes);
        }



        public static MvcHtmlString MzTextEditorFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            var id = htmlHelper.IdFor(expression);
            string script = "<script>$('#" + id + "').summernote({height: 150});</script>";
            return MvcHtmlString.Create(htmlHelper.TextAreaFor(expression, htmlAttributes).ToString() + script
                + htmlHelper.ValidationMessageFor(expression, "", new { @class = "text-danger" }));
        }

        public static MvcHtmlString MzTimePickerFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            var id = htmlHelper.IdFor(expression);
            string script = "<script>$('#" + id + "').timepicker({showMeridian:false, showSeconds:true, defaultTime:false, minuteStep:1, secondStep:1});</script>";
            return MvcHtmlString.Create(htmlHelper.MzTextBoxFor(expression, htmlAttributes).ToString() + script);
        }



        /// <summary>
        /// Returns a checkbox for each of the provided <paramref name="items"/>.
        /// </summary>
        public static MvcHtmlString CheckBoxListFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListItem> items, object htmlAttributes = null)
        {
            var listName = ExpressionHelper.GetExpressionText(expression);
            var metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            items = GetCheckboxListWithDefaultValues(metaData.Model, items);
            return htmlHelper.CheckBoxList(listName, items, htmlAttributes);
        }


        /// <summary>
        /// Returns a checkbox for each of the provided <paramref name="items"/>.
        /// </summary>
        public static MvcHtmlString CheckBoxList(this HtmlHelper htmlHelper, string listName, IEnumerable<SelectListItem> items, object htmlAttributes = null)
        {
            var container = new TagBuilder("div");
            foreach (var item in items)
            {
                var label = new TagBuilder("label");
                label.MergeAttribute("class", "checkbox"); // default class
                label.MergeAttributes(new RouteValueDictionary(htmlAttributes), true);

                var cb = new TagBuilder("input");
                cb.MergeAttribute("type", "checkbox");
                cb.MergeAttribute("name", listName);
                cb.MergeAttribute("value", item.Value ?? item.Text);
                if (item.Selected)
                    cb.MergeAttribute("checked", "checked");

                label.InnerHtml = cb.ToString(TagRenderMode.SelfClosing) + item.Text;

                container.InnerHtml += label.ToString();
            }

            return new MvcHtmlString(container.ToString());
        }



        private static IEnumerable<SelectListItem> GetCheckboxListWithDefaultValues(object defaultValues, IEnumerable<SelectListItem> selectList)
        {
            var defaultValuesList = defaultValues as IEnumerable;

            if (defaultValuesList == null)
                return selectList;

            IEnumerable<string> values = from object value in defaultValuesList
                                         select Convert.ToString(value, System.Globalization.CultureInfo.CurrentCulture);

            var selectedValues = new HashSet<string>(values, StringComparer.OrdinalIgnoreCase);
            var newSelectList = new List<SelectListItem>();

            foreach (var item in selectList)
            {
                item.Selected = (item.Value != null) ? selectedValues.Contains(item.Value) : selectedValues.Contains(item.Text);
                newSelectList.Add(item);
            }


            return newSelectList;
        }
    }
}