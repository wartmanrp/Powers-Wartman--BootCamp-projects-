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

namespace Cts.Venture.Common.Exceptions
{
   /// <summary>
   /// The class holds infromation about business rules voilation.
   /// </summary>
   public class ErrorInfo
   {
      /// <summary>
      /// Name of the property that has incorrect value.
      /// </summary>
      public string PropertyName { get; private set; }

      /// <summary>
      /// Error message associated with the incorrect value.
      /// </summary>
      public string ErrorMessage { get; private set; }

      /// <summary>
      /// Extra information.
      /// </summary>
      public object Object { get; private set; }

      /// <summary>
      /// Default constructor.
      /// </summary>
      /// <param name="propertyName">Name of the property that has incorrect value.</param>
      /// <param name="errorMessage">Error message associated with the incorrect value.</param>
      /// <param name="onObject">Extra information.</param>
      public ErrorInfo(string propertyName, string errorMessage, object onObject)
      {
         this.PropertyName = propertyName;
         this.ErrorMessage = errorMessage;
         this.Object = onObject;
      }

      /// <summary>
      /// Default constructor.
      /// </summary>
      /// <param name="propertyName">Name of the property that has incorrect value.</param>
      /// <param name="errorMessage">Error message associated with the incorrect value.</param>
      public ErrorInfo(string propertyName, string errorMessage)
         : this(propertyName, errorMessage, null) { }

      /// <summary>
      /// Builds string representation of the error object with <c>PropertyName</c> and <c>ErrorMessage</c>.
      /// </summary>
      /// <returns>string representing <c>PropertyName</c> and <c>ErrorMessage</c></returns>
      public override string ToString()
      {
         return string.IsNullOrWhiteSpace(this.PropertyName) ?
             this.ErrorMessage : string.Format("Property '{0}' {1}", this.PropertyName, this.ErrorMessage);
      }
   }
}