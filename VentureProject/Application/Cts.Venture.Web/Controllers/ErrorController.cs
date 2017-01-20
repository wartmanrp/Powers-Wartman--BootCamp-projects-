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
using System.Web;
using System.Web.Mvc;

namespace Cts.Venture.Web.Controllers
{
    /// <summary>
    /// The error in the framework are divided into three categories. 
    ///     <list type="number">
    ///         <listheader>
    ///             <term>term</term>
    ///             <description>description</description>
    ///         </listheader>
    ///         <item><term>Ajax</term><description>Error occurred during ajax call.</description></item>
    ///         <item><term>Mvc</term><description>Error occurred during mvc routing call.</description></item>
    ///         <item><term>Non-Mvc</term><description>Error occurred before routing.</description></item>
    ///     </list>
    ///     <para>
    ///     The controller is used for routing and processing error Non-Mvc error information. The controller extensions method <c>ErrorViewFromString(string message)</c> or 
    ///     <c>ErrorViewFromString(List{T} message)</c> processes errors during ajax calls. The mvc attribute <see cref="System.Web.Mvc.HandleErrorAttribute"/> handles
    ///     Mvc specific attributes.
    ///     </para>
    /// </summary>

    public class ErrorController : Controller
    {
        /// <summary>
        /// Processed <c>ErrorNonMvc</c> view to display error information.
        /// </summary>
        /// <param name="exception">Contains error information.</param>
        /// <returns><c>ErrorNonMvc</c> view.</returns>
        public ActionResult HandleError(Exception exception)
        {
            return View("~/Views/Shared/ErrorNonMvc.cshtml", exception);
        }

    }
}