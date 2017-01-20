// Copyright (c) 2014 Computer Technology Solutions, Inc.  ALL RIGHTS RESERVED
// http://www.askcts.com
// Author: CTS, Inc.
// Product: Cts.Venture.Service
// Version: 1.0.1
// 
// ********************************************************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cts.Venture.Common
{
   /// <summary>
   /// The class holds all the common constants used between layers/tiers.
   /// </summary>
   public class Constant
   {
        /// <summary>
        /// Standard date format for the application
        /// </summary>
        public const string DATE_FORMAT = "MM/dd/yyyy";

        /// <summary>
        /// String used as key during caching of service layer context.
        /// </summary>
        public static string InfractureContext
        {
            get
            {
            return "_InfractureContext"; ;
            }
        }

   }
}
