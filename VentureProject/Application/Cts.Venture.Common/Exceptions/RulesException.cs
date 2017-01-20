// Copyright (c) 2014 Computer Technology Solutions, Inc.  ALL RIGHTS RESERVED
// http://www.askcts.com
// Author: CTS, Inc.
// Product: Cts.Venture.Service
// Version: 1.0.1
// 
// ********************************************************************************************************************************************

using System;
using System.Collections.Generic;

namespace Cts.Venture.Common.Exceptions
{
   /// <summary>
   /// The exception class is thrown when a business rule exceptions occurrs.
   /// </summary>
   [Serializable]
   public class RulesException : Exception
   {
      /// <summary>
      /// Default constructor.
      /// </summary>
      /// <param name="errors"></param>
      public RulesException(IEnumerable<ErrorInfo> errors)
      {
         Errors = errors;
      }

      /// <summary>
      /// Constructor.
      /// </summary>
      /// <param name="propertyName">Property name of the domain class that has incorrect value.</param>
      /// <param name="errorMessage">Error message associated with incorrect value.</param>
      public RulesException(string propertyName, string errorMessage)
         : this(propertyName, errorMessage, null) { }

      /// <summary>
      /// Constructor.
      /// </summary>
      /// <param name="propertyName">Property name of the domain class that has incorrect value.</param>
      /// <param name="errorMessage">Error message associated with incorrect value.</param>
      /// <param name="onObject">Extra information.</param>
      public RulesException(string propertyName, string errorMessage, object onObject)
      {
         Errors = new[] { new ErrorInfo(propertyName, errorMessage, onObject) };
      }

      /// <summary>
      /// List of <see cref="ErrorInfo"/> as <see cref="System.Collections.Generic.IEnumerable{T}"/>.
      /// </summary>
      public IEnumerable<ErrorInfo> Errors { get; private set; }

   }

}
