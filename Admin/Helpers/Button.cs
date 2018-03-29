using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MujZavod.Admin.Helpers
{
    public static class Button
    {
        

        public static MvcHtmlString MzButton(this HtmlHelper helper,
                                     string innerHtml,
                                     MzButton.MzButtonType mzButtonType,
                                     object htmlAttributes,
                                     string cssClass = null)
        {
            return MzButton(helper, innerHtml, mzButtonType,
                          HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes),
                          cssClass
            );
        }

        public static MvcHtmlString MzButton(this HtmlHelper helper,
                                           string innerHtml,
                                           MzButton.MzButtonType mzButtonType,
                                           IDictionary<string, object> htmlAttributes,
                                           string cssClass= null)
        {
            
            return MvcHtmlString.Create(new MzButton() {
                innerHtml = innerHtml,
                mzButtonType = mzButtonType,
                htmlAttributes = htmlAttributes,
                cssClass = cssClass
            }.ToString());
        }

        
    }

    public class MzButton
    {
        public enum MzButtonType { ADD, EDIT, DELETE, DETAIL, DEFAULT }

        public string innerHtml;
        public string js;
        public string href;
        public MzButtonType mzButtonType;
        public string cssClass;
        public IDictionary<string, object> htmlAttributes;

        public string iconClass;

        public override string ToString()
        {
            var builder = new TagBuilder("a");

            if (!string.IsNullOrWhiteSpace(cssClass))
                builder.AddCssClass(cssClass);
            builder.AddCssClass("btn");

            if (!string.IsNullOrWhiteSpace(href))
                builder.Attributes.Add("href", href);
            else
                builder.Attributes.Add("href", "#");

            if (!string.IsNullOrWhiteSpace(js))
                builder.Attributes.Add("onclick", js);


            var icon = new TagBuilder("span");
            icon.AddCssClass("btn-label-icon left fa");

            switch (mzButtonType)
            {
                case MzButtonType.ADD:
                    icon.AddCssClass("fa-plus");
                    builder.AddCssClass("btn-info");
                    break;
                case MzButtonType.EDIT:
                    icon.AddCssClass("fa-pencil");
                    builder.AddCssClass("btn-success");
                    break;
                case MzButtonType.DELETE:
                    icon.AddCssClass("fa-trash");
                    builder.AddCssClass("btn-danger");
                    break;
                case MzButtonType.DETAIL:
                    icon.AddCssClass("fa-sticky-note-o");
                    builder.AddCssClass("btn-default");
                    break;
                case MzButtonType.DEFAULT:
                    builder.AddCssClass("btn-default");
                    break;
            }

            if (!string.IsNullOrWhiteSpace(iconClass))
                icon.AddCssClass(iconClass);

            builder.InnerHtml = icon.ToString() + innerHtml;

            builder.MergeAttributes(htmlAttributes);
            return builder.ToString();
        }
    }
}