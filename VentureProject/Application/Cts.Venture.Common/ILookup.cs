// ********************************************************************************************************************************************
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
   /// The interface is implemented by domain or others to enable them to be displayed as name/value pair objects.
   /// </summary>
    public interface ILookup
    {
       /// <summary>
       /// The value part of the name/value pair.
       /// </summary>
        string DataValue { get; }

       /// <summary>
       /// The name part of the name/value pair.
       /// </summary>
        string DataText { get; }
    }
}
