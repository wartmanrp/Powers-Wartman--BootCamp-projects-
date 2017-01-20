// ********************************************************************************************************************************************
// Copyright (c) 2014 Computer Technology Solutions, Inc.  ALL RIGHTS RESERVED
// http://www.askcts.com
// Author: CTS, Inc.
// Product: Cts.Venture.Service
// Version: 1.0.1
// Date: 4/12/2013
// 
// ********************************************************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Cts.Venture.Data;

namespace Cts.Venture.Service
{
   /// <summary>
   /// The abstract class should be inherited by all the Service classes. The class provides EF context for communicating with database.
   /// </summary>
   /// <history>
   /// Date       Author         Change Reason           Change Description
   /// --------------------------------------------------------------------------------------------------
   ///
   /// --------------------------------------------------------------------------------------------------
   /// </history>
   public abstract class BaseService
   {
      /// <summary>
      /// Entity Framework database context.
      /// </summary>
      internal VENTUREDbContext Db { get; set; }

      /// <summary>
      /// Default constructor.
      /// </summary>
      /// <param name="Dbctx">Entity Framework database context.</param>
      /// <history>
      /// Date       Author         Change Reason           Change Description
      /// --------------------------------------------------------------------------------------------------
      ///
      /// --------------------------------------------------------------------------------------------------
      /// </history>
      internal BaseService(VENTUREDbContext Dbctx)
      {
         Db = Dbctx;
      }
   }
}
