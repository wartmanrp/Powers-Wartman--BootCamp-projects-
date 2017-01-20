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

namespace Cts.Venture.Service.Exceptions
{
   /// <summary>
   /// The exception that is thrown when user is not found or credentials are not correct.
   /// </summary>
   /// <history>
   /// Date       Author         Change Reason           Change Description
   /// --------------------------------------------------------------------------------------------------
   ///
   /// --------------------------------------------------------------------------------------------------
   /// </history>
   [Serializable]
   public class UserNotFoundException : Exception
   {
      /// <summary>
      /// Default constructor.
      /// </summary>
      public UserNotFoundException() { }

      /// <summary>
      /// Constructor.
      /// </summary>
      /// <param name="message">Message of the exception.</param>
      public UserNotFoundException(string message) : base(message) { }

      /// <summary>
      /// Constructor.
      /// </summary>
      /// <param name="message">Message of the exception.</param>
      /// <param name="inner">Child exception.</param>
      public UserNotFoundException(string message, Exception inner) : base(message, inner) { }

      /// <summary>
      /// Constructor for serialization.
      /// </summary>
      /// <param name="info"><see cref="System.Runtime.Serialization.SerializationInfo"/> that holds serialization and deserialization information.</param>
      /// <param name="context"><see cref="System.Runtime.Serialization.StreamingContext"/> that holds streaming state.</param>
      protected UserNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
         : base(info, context) { }
   }
}
