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
    /// The class holds state information for the service layer.
    /// </summary>
    public class Context : IDisposable
    {
        /// <summary>
        /// Entity Framework database context.
        /// </summary>
        public VENTUREDbContext DbContext { get; set; }
        
        /// <summary>
        /// Default constructor to initialize instance variables and properties.
        /// </summary>
        /// <history>
        /// Date   Author    Change Reason     Change Description
        /// ----------------------------------------------------------------
        ///
        /// ----------------------------------------------------------------
        /// </history>
        public Context()
        {
            DbContext = new VENTUREDbContext();
            
            DbContext.Configuration.ValidateOnSaveEnabled = false;
            DbContext.Configuration.ProxyCreationEnabled = false;
        }

        #region IDisposable Members

       /// <summary>
       /// Disposes EF context to close db connection.
       /// </summary>
        public void Dispose()
        {
            DbContext.Dispose();
        }

        #endregion
    }
}
