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

using Cts.Venture.Service;
using Cts.Venture.Common.Helpers;
using Cts.Venture.Common;
using Cts.Venture.Common.PaginateList;
using Newtonsoft.Json;

namespace Cts.Venture.Web.Controllers
{
    /// <summary>
    /// The controller class that all other controllers in the framework must inherit from. 
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// Static controller to provide static variable initializations.
        /// </summary>
        static BaseController()
        {
            PageSize = ConfigurationHelper.AppSetting<int>("TablePageSize", 20);
        }

        /// <summary>
        /// The <see cref="Cts.Venture.Service.Context"/> that wraps Entity Framework context.
        /// </summary>
        protected Context ServiceContext
        {
            get
            {
                return HttpContext.Items[Constant.InfractureContext] as Context;
            }
        }

        /// <summary>
        /// Default page size for table pagination. The value is populated from config file.
        /// </summary>
        protected static int PageSize { get; set; }

        /// <summary>
        /// Parse json object to build a string representation that can be included in query.
        /// </summary>
        /// <param name="filterJson"></param>
        /// <returns></returns>
        protected static string BuildFilter(string filterJson)
        {
            if (string.IsNullOrEmpty(filterJson))
            {
                return null;
            }
            else
            {
                FilterWrapper filters = JsonConvert.DeserializeObject<FilterWrapper>(filterJson);
                return filters.GetFilter();
            }
        }

    }
}
