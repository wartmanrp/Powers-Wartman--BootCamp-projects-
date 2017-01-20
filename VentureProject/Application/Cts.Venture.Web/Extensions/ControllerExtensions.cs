// ********************************************************************************************************************************************
// Copyright (c) 2014 Computer Technology Solutions, Inc.  ALL RIGHTS RESERVED
// http://www.askcts.com
// Author: CTS, Inc.
// Product: Cts.Venture.Service
// Version: 1.0.1
// The package incapsulate UI functionalities. The package is based on mvc pattern to provide better encapsulation and separation of concern.
// ********************************************************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Routing;
using Cts.Venture.Common;
using Cts.Venture.Common.Exceptions;
using Cts.Venture.Domain;

namespace Cts.Venture.Web
{
    /// <summary>
    /// Defines extension for the <c>Controllers</c> in the application.
    /// </summary>
    public static class ControllerExtensions
    {
        /// <summary>
        /// Extension method to process route defined <c>Home</c> route name.
        /// </summary>
        /// <returns>View defined by <c>Home</c> route name.</returns>
        public static ActionResult RedirectToLocal(this Controller controller)
        {
            return new RedirectToRouteResult("Home", new System.Web.Routing.RouteValueDictionary());
        }

        /// <summary>
        /// Extension method to set the Response Status Code to 400 and suppresses default error handling by IIS.
        /// </summary>
        /// <param name="controller">Extension method for.</param>
        public static void SetResponseError400(this Controller controller)
        {
            controller.Response.StatusCode = 400;
            controller.Response.TrySkipIisCustomErrors = true;
        }

        /// <summary>
        /// Extension method to process <c>Error</c> view to display model and error information.
        /// </summary>
        /// <param name="controller">Extension method for.</param>
        /// <param name="model">Data to be displayed with the view.</param>
        /// <returns><c>Error</c> view. </returns>
        public static PartialViewResult ErrorView(this Controller controller, object model = null)
        {
            return controller.ErrorView("~/Views/Shared/Error.cshtml", model);
        }

        /// <summary>
        /// Extension method to process a view to display model and error information. 
        /// </summary>
        /// <param name="controller">Extension method for.</param>
        /// <param name="viewName">View to be processed.</param>
        /// <param name="model">Data to be displayed with the view.</param>
        /// <returns>Partial view defined by <c>viewName</c> param.</returns>
        public static PartialViewResult ErrorView(this Controller controller, string viewName, object model = null)
        {
            controller.SetResponseError400();
            controller.ViewData.Model = model;
            return new PartialViewResult
            {
                ViewName = viewName,
                ViewData = controller.ViewData,
                TempData = controller.TempData,
                ViewEngineCollection = controller.ViewEngineCollection
            };
        }

        /// <summary>
        /// Extension method to process <see cref="System.Web.Mvc.ContentResult"/> to contain message.
        /// </summary>
        /// <param name="controller">Extension method for.</param>
        /// <param name="message">string to be formatted for displaying as error.</param>
        /// <returns><see cref="System.Web.Mvc.ContentResult"/> view.</returns>
        public static ContentResult ErrorViewFromString(this Controller controller, string message)
        {
            controller.SetResponseError400();

            ContentResult errorResponse = new ContentResult();
            errorResponse.Content = string.Format("<li>{0}</li>", message);

            return errorResponse;
        }

        /// <summary>
        /// Extension method to process <see cref="System.Web.Mvc.ContentResult"/> to contain message.
        /// </summary>
        /// <param name="controller">Extension method for.</param>
        /// <param name="messages">string collection to be formatted for displaying as error.</param>
        /// <returns><see cref="System.Web.Mvc.ContentResult"/> view.</returns>
        public static ContentResult ErrorViewFromString(this Controller controller, List<string> messages)
        {
            controller.SetResponseError400();

            ContentResult errorResponse = new ContentResult();
            errorResponse.Content = string.Format("<li>{0}</li>", string.Join("</li><li>", messages.ToArray()));
                
            return errorResponse;
        }


        /// <summary>
        /// Extension method to add errors from a <c>RulesException</c> as model errors.
        /// </summary>
        /// <param name="modelState">Extension method for.</param>
        /// <param name="ex">Used to build model errors.</param>
        public static void AddRuleErrors(this ModelStateDictionary modelState, RulesException ex)
        {
            foreach (var x in ex.Errors)
            {
                modelState.AddModelError(x.PropertyName, x.ErrorMessage);
            }
        }

        /// <summary>
        /// Extension method to add inner most error from a <c>Exception</c> as model errors.
        /// </summary>
        /// <param name="modelState">Extension method for.</param>
        /// <param name="ex">Used to build model errors.</param>
        public static void AddErrors(this ModelStateDictionary modelState, Exception ex)
        {
            Exception inner = ex.InnerException;
            while (inner != null)
            {
                ex = inner;
                inner = inner.InnerException; ;
            }

            modelState.AddModelError(string.Empty, ex.Message);

        }
    }
}
