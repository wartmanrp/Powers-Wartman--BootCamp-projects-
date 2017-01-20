using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cts.Venture.Common.PaginateList
{
    /// <summary>
    /// Stores paging and sorting information.
    /// </summary>
    public class PageSortCriteria
    {
        
        /// <summary>
        /// Current page number.
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Column to sort with. 
        /// <remarks>
        /// This value must match entity's property name to generate orderby clause.
        /// </remarks>
        /// </summary>
        public string Sort { get; set; }

        /// <summary>
        /// Sort direction.
        /// </summary>
        public string Order { get; set; }

        /// <summary>
        /// Search string to generate where clause.
        /// </summary>
        public string Filter { get; set; }

      
    }
}
