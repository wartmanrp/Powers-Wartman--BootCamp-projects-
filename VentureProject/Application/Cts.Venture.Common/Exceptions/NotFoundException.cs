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

namespace Cts.Venture.Common.Exceptions
{
   /// <summary>
   /// Exception for when a record can't be found
   /// </summary>
   [Serializable]
   public class NotFoundException : Exception
   {
      /// <summary>
      /// Default constructor.
      /// </summary>
      public NotFoundException() : base("The record was not found.") { }

      /// <summary>
      /// Constructor.
      /// </summary>
      /// <param name="message">Message of the exception.</param>
      public NotFoundException(string message) : base(message) { }

      /// <summary>
      /// Constructor.
      /// </summary>
      /// <param name="message">Message of the exception.</param>
      /// <param name="inner">Child exception.</param>
      public NotFoundException(string message, Exception inner) : base(message, inner) { }

      /// <summary>
      /// Constructor for serialization.
      /// </summary>
      /// <param name="info"><see cref="System.Runtime.Serialization.SerializationInfo"/> that holds serialization and deserialization information.</param>
      /// <param name="context"><see cref="System.Runtime.Serialization.StreamingContext"/> that holds streaming state.</param>
      protected NotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
         : base(info, context) { }
   }
}
