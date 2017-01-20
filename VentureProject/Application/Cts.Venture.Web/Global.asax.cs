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
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net.Config;
using System.Text;
using log4net;

using Cts.Venture.Common;
using Cts.Venture.Service;
using Cts.Venture.Service.Exceptions;
using Cts.Venture.Web.Binders;
using Cts.Venture.Web.Controllers;

namespace Cts.Venture.Web
{

   /// <summary>
   /// <see cref="System.Web.HttpApplication"/> object to hook into webserver pipeline.
   /// </summary>
   public class MvcApplication : System.Web.HttpApplication
   {
      /// <summary>
      /// 
      /// </summary>
      public static readonly ILog Log = LogManager.GetLogger(typeof(MvcApplication));

      /// <summary>
      /// Registers and configure all application configuration needs.
      /// </summary>
      protected void Application_Start()
      {
         // Register the default hubs route: ~/signalr
         
         //TODO this might screw everything up
         //RouteTable.Routes.MapHubs();

         // for logging
         XmlConfigurator.Configure();

         AreaRegistration.RegisterAllAreas();

         FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
         RouteConfig.RegisterRoutes(RouteTable.Routes);
         BundleConfig.RegisterBundles(BundleTable.Bundles);
         AuthConfig.RegisterAuth();

         ModelBinders.Binders.Add(typeof(string), new TrimModelBinder());

      }

      /// <summary>
      /// Initialize resources for a request.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      protected void Application_BeginRequest(object sender, EventArgs e)
      {
         Log.Debug("Appliation Request Begins");
         HttpContext.Current.Items[Constant.InfractureContext] = new Context();
      }

      /// <summary>
      /// Destroyes resources used in the request.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      protected void Application_EndRequest(object sender, EventArgs e)
      {
         var ctx = HttpContext.Current.Items[Constant.InfractureContext] as Context;
         if (ctx != null)
         {
            ctx.Dispose();
            Log.Debug("Appliation Request Ends");
         }
      }

      /// <summary>
      /// Global exception logger.
      /// </summary>
      protected void Application_Error()
      {
         Exception exception = Server.GetLastError();
         Log.Fatal(exception);

         Response.Clear();
         Server.ClearError();

         Response.StatusCode = 500;
            Response.TrySkipIisCustomErrors = true;

            var routeData = new RouteData();
         routeData.Values["controller"] = "Errors";
         routeData.Values["action"] = "HandleError";
         routeData.Values["exception"] = exception;

         IController errorsController = new ErrorController();
         var requestCtx = new RequestContext(new HttpContextWrapper(Context), routeData);
         errorsController.Execute(requestCtx);
      }
   }
}