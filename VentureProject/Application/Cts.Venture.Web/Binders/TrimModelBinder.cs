// ********************************************************************************************************************************************
// Copyright (c) 2014 Computer Technology Solutions, Inc.  ALL RIGHTS RESERVED
// http://www.askcts.com
// Author: CTS, Inc.
// Product: Cts.Venture.Service
// Version: 1.0.1
// The package incapsulate UI functionalities. The package is based on mvc pattern to provide better encapsulation and separation of concern.
// ********************************************************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cts.Venture.Web.Binders
{
    /// <summary>
    /// Trim leading and trailing whitespace. Also, converts just whitespaces to null.
    /// </summary>
    public class TrimModelBinder : IModelBinder
    {
        #region IModelBinder Members

        /// <summary>
        /// Implemented. Binds the model to a value by using the specified binding context to trim leading or trailing spaces.
        /// </summary>
        /// <param name="controllerContext">The controller context. Not used in the implementation.</param>
        /// <param name="bindingContext">The binding context.</param>
        /// <returns>The trimmed value. In case of empty value null is returned.</returns>
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueResult == null || string.IsNullOrEmpty(valueResult.AttemptedValue) || string.IsNullOrWhiteSpace(valueResult.AttemptedValue))
                return null;

            return valueResult.AttemptedValue.Trim();
        }

        #endregion

    }
}