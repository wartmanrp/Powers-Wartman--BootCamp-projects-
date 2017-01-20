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
using System.Web.Routing;

namespace Cts.Venture.Web
{
    /// <summary>
    /// Configures routes for the application.
    /// </summary>
   public class RouteConfig
   {
       /// <summary>
       /// Addes routes to <c>routes</c> collection.
       /// </summary>
       /// <param name="routes">Collection of routes</param>
      public static void RegisterRoutes(RouteCollection routes)
      {
         routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

         routes.MapRoute(
             name: "Home",
             url: "ViewToday/ViewToday",
             defaults: new { controller = "ViewToday", action = "Index" }
         );

         routes.MapRoute(
             name: "Default",
             url: "{controller}/{action}/{key}",
             defaults: new { controller = "ViewToday", action = "Index", key = UrlParameter.Optional }
         );
      }
   }
}