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

namespace Cts.Venture.Web.Attributes
{
    /// <summary>
    /// The class is responsible for filtering ajax routes (calls). Any call that are not an ajax call, a  
    /// <see cref="System.Web.HttpException"/> is thrown.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class AjaxOnlyAttribute : FilterAttribute, IAuthorizationFilter
    {
        /// <summary>
        /// Called to validate as ajax call.    
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        /// <exception cref="System.Web.HttpException">Thrown when the call is not ajax call.</exception>
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAjaxRequest())
            {
                throw new System.Web.HttpException("Access method not supported.");
            }
        }

    }
}