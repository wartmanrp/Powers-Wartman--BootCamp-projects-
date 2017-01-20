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
using System.Data.Entity.Validation;
using Cts.Venture.Common.PaginateList;
using Cts.Venture.Common.Exceptions;

namespace Cts.Venture.Common
{
   /// <summary>
   /// The class holds extension methods.
   /// </summary>
   public static class Extensions
   {
        /// <summary>
        /// Creates a subset of this collection of objects that can be individually accessed by index and containing metadata about the collection of objects the subset was created from.
        /// </summary>
        /// <typeparam name="T">The type of object the collection should contain.</typeparam>
        /// <param name="superset">The collection of objects to be divided into subsets. If the collection implements <see cref="IQueryable{T}"/>, it will be treated as such.</param>
        /// <param name="filter">The condition used to filter the result.</param>
        /// <param name="sort">The column (entity property) that is used for sorting.</param>
        /// <param name="order">The order used for sorting.</param>
        /// <param name="index">The index of the subset of objects to be contained by this instance.</param>
        /// <param name="pageSize">The maximum size of any individual subset.</param>
        /// <returns>A subset of this collection of objects that can be individually accessed by index and containing metadata about the collection of objects the subset was created from.</returns>
        /// <seealso cref="PagedList{T}"/>
        public static IPagedList<T> ToPagedList<T>(this IQueryable<T> superset, string filter, string sort, string order, int index = 1, int pageSize = 25)
      {
         if (string.IsNullOrEmpty(sort))
         {
            throw new FrameworkException("The paging framework requires sort column (entity property) which was not supplied.");
         }
         else
         {
            if (string.IsNullOrEmpty(order))
            {
               order = SortDirection.Ascending.ToString();
            }
         }
         return new PagedList<T>(superset, filter, sort, order, index, pageSize);
      }

      /// <summary>
      /// Converts the <c>DbEntityValidationException</c> to a <c>RulesException</c>.
      /// </summary>
      /// <param name="ve">DbEntityValidationException to convert</param>
      /// <returns>Application specific rules expection <see cref="RulesException"/></returns>
      public static RulesException ToRulesException(this DbEntityValidationException ve)
      {
         return new RulesException(
             ve.EntityValidationErrors.First().ValidationErrors
             .Select(e => new ErrorInfo(e.PropertyName, e.ErrorMessage)));
      }

      /// <summary>
      /// Formats a timespan into days, hours, minutes, seconds
      /// </summary>
      /// <param name="span">TimeSpan to format</param>
      /// <returns>Time in string format</returns>
      public static string ToReadableString(this TimeSpan span)
      {
         string formatted = string.Format("{0}{1}{2}{3}",
             span.Days > 0 ? string.Format("{0:0} days, ", span.Days) : string.Empty,
             span.Hours > 0 ? string.Format("{0:0} hours, ", span.Hours) : string.Empty,
             span.Minutes > 0 ? string.Format("{0:0} minutes, ", span.Minutes) : string.Empty,
             span.Seconds > 0 ? string.Format("{0:0} seconds", span.Seconds) : string.Empty);

         if (formatted.EndsWith(", ")) formatted = formatted.Substring(0, formatted.Length - 2);

         return formatted;
      }

      /// <summary>
      /// Format double values
      /// </summary>
      /// <param name="num">Number to format</param>
      /// <param name="format">Format string</param>
      /// <returns>Double formatted as a string</returns>
      public static string ToFormatString(this double? num, string format)
      {
         return !num.HasValue ? string.Empty : num.Value.ToString(format);
      }

      /// <summary>
      /// Format double values as 0.00
      /// </summary>
      /// <param name="amount">Number to format</param>
      /// <returns>Double formatted as a string</returns>
      public static string ToFormatString(this double? amount)
      {
         return amount.ToFormatString("0.00");
      }

      /// <summary>
      /// Format Boolean values as Yes or No
      /// </summary>
      /// <param name="value">Boolean value to format</param>
      /// <returns>Boolean formatted as a Yes/No string</returns>
      public static string ToFormatString(this bool value)
      {
         return value ? "Yes" : "No";
      }

      /// <summary>
      /// Format Boolean values as Yes or No
      /// </summary>
      /// <param name="value">Boolean value to format</param>
      /// <returns>Boolean formatted as a Yes/No string</returns>
      public static string ToFormatString(this bool? value)
      {
         return !value.HasValue ? string.Empty :
             value.Value.ToFormatString();
      }


   }
}
