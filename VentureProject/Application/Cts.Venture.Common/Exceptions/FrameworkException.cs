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
    /// Unknown error Exception for the framework
    /// </summary>
    [Serializable]
    public class FrameworkException : Exception
    {
       /// <summary>
       /// Default constructor.
       /// </summary>
        public FrameworkException() : base("There are unknown framework error(s).") { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Message of the exception.</param>
        public FrameworkException(string message) : base(message) { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Message of the exception.</param>
        /// <param name="inner">Child exception.</param>
        public FrameworkException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Constructor for serialization.
        /// </summary>
        /// <param name="info"><see cref="System.Runtime.Serialization.SerializationInfo"/> that holds serialization and deserialization information.</param>
        /// <param name="context"><see cref="System.Runtime.Serialization.StreamingContext"/> that holds streaming state.</param>
        protected FrameworkException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
