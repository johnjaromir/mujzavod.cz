using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MujZavod.Admin.Helpers
{
    public static class Button
    {
        public enum MzButtonType { ADD, EDIT, DELETE }

        public static MvcHtmlString MzButton(this HtmlHelper helper,
                                     string innerHtml,
                                     MzButtonType mzButtonType,
                                     object htmlAttributes)
        {
            return MzButton(helper, innerHtml, mzButtonType,
                          HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)
            );
        }

        public static MvcHtmlString MzButton(this HtmlHelper helper,
                                           string innerHtml,
                                           MzButtonType mzButtonType,
                                           IDictionary<string, object> htmlAttributes)
        {
            var builder = new TagBuilder("button");
            builder.InnerHtml = innerHtml;

            switch(mzButtonType)
            {
                case MzButtonType.ADD:
                    builder.AddCssClass("btn btn-info");
                    break;
                case MzButtonType.EDIT:
                    builder.AddCssClass("btn btn-success");
                    break;
                case MzButtonType.DELETE:
                    builder.AddCssClass("btn btn-danger");
                    break;
            }

            builder.MergeAttributes(htmlAttributes);
            return MvcHtmlString.Create(builder.ToString());
        }
    }
}