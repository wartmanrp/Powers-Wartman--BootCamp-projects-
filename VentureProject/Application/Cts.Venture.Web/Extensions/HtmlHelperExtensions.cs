using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Cts.Venture.Common;
using System.Web.Mvc.Ajax;

namespace Cts.Venture.Web
{
   /// <summary>
   /// 
   /// </summary>
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Extension method to build a dropdown list using <see cref="Cts.Venture.Common.ILookup"/> collection type.
        /// </summary>
        /// <param name="helper">Extension method for.</param>
        /// <param name="name">string for name attribute value.</param>
        /// <param name="list"><see cref="Cts.Venture.Common.ILookup"/> collection to list.</param>
        /// <param name="selectedValue">Item that will be selected.</param>
        /// <param name="htmlAttributes">attributes to be added to the html control.</param>
        /// <param name="isOptional">true - adds an extra item at the top with empty text as Text and null as Value.</param>
        /// <returns><see cref="System.Web.Mvc.MvcHtmlString"/> representing select element.</returns>
        public static MvcHtmlString DropDownListEx(this HtmlHelper helper, string name, IEnumerable<ILookup> list, object selectedValue, object htmlAttributes, bool isOptional = false)
        {

            TagBuilder dropdown = new TagBuilder("select");

            //Setting the name and id attribute with name parameter passed to this method.
            dropdown.Attributes.Add("name", name);
            dropdown.Attributes.Add("id", name);

            StringBuilder options = new StringBuilder();
            //Iterated over the IEnumerable list.
            if (isOptional)
            {
                options = options.Append(string.Format("<option value='{0}' {1}>{2}</option>",
                    null,
                    string.Empty,
                    string.Empty));
            }

            foreach (var item in list)
            {
                options = options.Append(string.Format("<option value='{0}' {1}>{2}</option>",
                    item.DataValue,
                    item.DataValue.Equals(selectedValue == null ? string.Empty : selectedValue.ToString()) ? "selected" : string.Empty,
                    item.DataText));

            }


            dropdown.InnerHtml = options.ToString();
            //Assigning the attributes passed as a htmlAttributes object.
            dropdown.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            return MvcHtmlString.Create(dropdown.ToString(TagRenderMode.Normal));
        }

        /// <summary>
        /// Extension method to build an anchor element that contains the URL to the specified action method;
        /// when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
        /// </summary>
        /// <param name="ajaxHelper">Extension method for.</param>
        /// <param name="html">The text that will be included in the anchor element.</param>
        /// <param name="actionName">The name of the action method.</param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <returns>An anchor element.</returns>
        public static MvcHtmlString IncludeHtmlActionLink(this AjaxHelper ajaxHelper, string html, string actionName, AjaxOptions ajaxOptions)
        {
            var link = ajaxHelper.ActionLink("[$replace$]", actionName, ajaxOptions).ToHtmlString();
            return new MvcHtmlString(link.Replace("[$replace$]", html));
        }

        /// <summary>
        /// Extension method to build an anchor element that contains the URL to the specified action method;
        /// when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
        /// </summary>
        /// <param name="ajaxHelper">Extension method for.</param>
        /// <param name="html">The text that will be included in the anchor element.</param>
        /// <param name="actionName">The name of the action method.</param>
        /// <param name="routeValues">
        /// An object that contains the parameters for a route. The parameters are retrieved through reflection by 
        /// examining the properties of the object. This object is typically created by using object initializer syntax.
        /// </param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An anchor element.</returns>
        public static MvcHtmlString IncludeHtmlActionLink(this AjaxHelper ajaxHelper, string html, string actionName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes = null)
        {
            var link = ajaxHelper.ActionLink("[$replace$]", actionName, routeValues, ajaxOptions, htmlAttributes).ToHtmlString();
            return new MvcHtmlString(link.Replace("[$replace$]", html));
        }

        /// <summary>
        /// Extension method to build an anchor element that contains the URL to the specified action method;
        /// when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
        /// </summary>
        /// <param name="ajaxHelper">Extension method for.</param>
        /// <param name="html">The text that will be included in the anchor element.</param>
        /// <param name="actionName">The name of the action method.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="routeValues">
        /// An object that contains the parameters for a route. The parameters are retrieved through reflection by 
        /// examining the properties of the object. This object is typically created by using object initializer syntax.
        /// </param>
        /// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An anchor element.</returns>
        public static MvcHtmlString IncludeHtmlActionLink(this AjaxHelper ajaxHelper, string html, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes = null)
        {
            var link = ajaxHelper.ActionLink("[$replace$]", actionName, controllerName, routeValues, ajaxOptions, htmlAttributes).ToHtmlString();
            return new MvcHtmlString(link.Replace("[$replace$]", html));
        }

        /// <summary>
        /// Extension method to build date string for nullable DateTime.
        /// </summary>
        /// <param name="htmlHelper">Extension method for.</param>
        /// <param name="datetime">The datetime that will used to generate string.</param>
        /// <returns>String representing date or empty string if the datetime parameter is null.</returns>
        public static MvcHtmlString FormatDate(this HtmlHelper htmlHelper, DateTime? datetime)
        {
            if (datetime.HasValue)
            {
                return new MvcHtmlString(datetime.Value.ToString(Constant.DATE_FORMAT));
            }
            else
            {
                return new MvcHtmlString(string.Empty);
            }
        }

        /// <summary>
        /// Extension method to build date string for DateTime.
        /// </summary>
        /// <param name="htmlHelper">Extension method for.</param>
        /// <param name="datetime">The datetime that will used to generate string.</param>
        /// <returns>String representing date or empty string if the datetime is set to MinValue.</returns>
        public static MvcHtmlString FormatDate(this HtmlHelper htmlHelper, DateTime datetime)
        {
            if (datetime.Equals(DateTime.MinValue))
            {
                return new MvcHtmlString(string.Empty); 
            }
            else
            {
                return new MvcHtmlString(datetime.ToString(Constant.DATE_FORMAT)); 
            }
        }
    }
}