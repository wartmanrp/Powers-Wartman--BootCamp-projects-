// ********************************************************************************************************************************************
// Copyright (c) 2014 Computer Technology Solutions, Inc.  ALL RIGHTS RESERVED
// http://www.askcts.com
// Author: CTS, Inc.
// Product: Cts.Venture.Service
// Version: 1.0.1
// The package incapsulate UI functionalities. The package is based on mvc pattern to provide better encapsulation and separation of concern.
// ********************************************************************************************************************************************

using System.Web;
using System.Web.Mvc;

namespace Cts.Venture.Web
{
    /// <summary>
    /// Configures filter attributes for the application.
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Adds filter attributes to <c>filters</c> collection.
        /// </summary>
        /// <param name="filters">Configured filter collection.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            HandleErrorAttribute mvcErrorHandler = new HandleErrorAttribute();
            mvcErrorHandler.View = "~/Views/Shared/ErrorMvc.cshtml";
            filters.Add(mvcErrorHandler);
        }
    }
}