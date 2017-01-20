// Copyright (c) 2014 Computer Technology Solutions, Inc.  ALL RIGHTS RESERVED
// http://www.askcts.com
// Author: CTS, Inc.
// Product: Cts.Venture.Service
// Version: 1.0.1
// 
// ********************************************************************************************************************************************

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cts.Venture.Common.Helpers
{
   /// <summary>
   /// Reads configuration information from config file.
   /// </summary>
   public static class ConfigurationHelper
   {
      /// <summary>
      /// Returns valud from appSettings collection in configuration file.
      /// </summary>
      /// <typeparam name="T">Generic type</typeparam>
      /// <param name="setting">Key value of the setting used to retrieve the value</param>
      /// <param name="defaultValue">Value that will be returned if appSettings entry in not found</param>
      /// <returns>Generic type</returns>
      public static T AppSetting<T>(string setting, T defaultValue)
      {
         try
         {
            object appSetting = ConfigurationManager.AppSettings[setting];

            return appSetting == null ? defaultValue : (T)Convert.ChangeType(appSetting, typeof(T));
         }
         catch
         {
            return defaultValue;
         }
      }
   }
}
