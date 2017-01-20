// ********************************************************************************************************************************************
// Copyright (c) 2014 Computer Technology Solutions, Inc.  ALL RIGHTS RESERVED
// http://www.askcts.com
// Author: CTS, Inc.
// Product: Cts.Venture.Service
// Version: 1.0.1
// The package incapsulate UI functionalities. The package is based on mvc pattern to provide better encapsulation and separation of concern.
// ********************************************************************************************************************************************

using System.Web;
using System.Web.Optimization;

namespace Cts.Venture.Web
{
    /// <summary>
    /// Configures javascript and css bundles for the application. 
    /// </summary>
   public class BundleConfig
   {
       /// <summary>
       /// Added javascript and css bundle to <c>bundles</c> collection.
       /// </summary>
       /// <param name="bundles">Configured bundle collection.</param>      
      public static void RegisterBundles(BundleCollection bundles)
      {
         bundles.Add(new ScriptBundle("~/js/core").Include(
                     "~/Scripts/jquery-{version}.js",
                     "~/Scripts/jquery.unobtrusive*",
                     "~/Scripts/bootstrap.js",
                     "~/Scripts/respond.js",
                     "~/Scripts/cts.core.js",
                     "~/Scripts/cts.validate-unobtrusive.js"));

          bundles.Add(new ScriptBundle("~/bundles/val").Include(
              "~/Scripts/jquery.validate*"
              ));

          bundles.Add(new ScriptBundle("~/bundles/table").Include(
              "~/Scripts/cts.paginate-table.js"
              ));

          bundles.Add(new StyleBundle("~/content/core").Include("~/Content/bootstrap.css", "~/Content/cts.core.css", "~/Content/MyCss.css", "~/Content/font-awesome/css/font-awesome.css"));
      }
   }
}