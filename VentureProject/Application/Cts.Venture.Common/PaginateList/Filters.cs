using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cts.Venture.Common.PaginateList
{
    /// <summary>
    /// Process filter collection to getting ready for query.
    /// </summary>
    public class FilterWrapper
    {
        /// <summary>
        /// List of filters that are used to filter the resultset.
        /// </summary>
        public List<Filter> Filters { get; set; }

        /// <summary>
        /// Parses the Filters value and build a formatted string for including into query.
        /// </summary>
        /// <returns>Formatted string for to be used in query.</returns>
        public string GetFilter()
        {
            string and = string.Empty;
            StringBuilder filterBuilder = new StringBuilder();
            StringBuilder filterValuesBuilder = new StringBuilder();

            foreach (Filter filter in Filters)
            {
                
                if (filter.PropertyDataType == "int")
                {
                    filterBuilder.AppendFormat("{0}{1}={2}", and, filter.PropertyName, filter.PropertyValue);

                }
                if ((filter.PropertyDataType.ToLower() == "datetime") || (filter.PropertyDataType.ToLower() == "date"))
                {
                    DateTime datetime;
                    if (DateTime.TryParse(filter.PropertyValue, out datetime))
                    {
                        filterBuilder.AppendFormat("{0}{1}={2}", and, filter.PropertyName, "DateTime(" + datetime.Ticks + ")");
                    }
                }
                else if (string.IsNullOrEmpty(filter.PropertyDataType) || (filter.PropertyDataType.ToLower() == "string"))
                {
                    filterBuilder.AppendFormat("{0}{1}=\"{2}\"", and, filter.PropertyName, filter.PropertyValue);
                }

                and = " && ";
            }

            return filterBuilder.Append(filterValuesBuilder.ToString()).ToString();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Filter()
        {
            PropertyDataType = "string";
        }

        /// <summary>
        /// 
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PropertyValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PropertyDataType { get; set; }
    }
}
