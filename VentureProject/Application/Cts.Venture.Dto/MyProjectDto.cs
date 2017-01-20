using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cts.Venture.Dto
{
   /// <summary>This class represents the data used to fill the search results partial.</summary>
   /// <author>Powers Wartman</author>
   /// <date>September 21, 2016</date>
   /// <copyright> 
   /// Copyright (c) 2016 Computer Technology Solutions, Inc.  ALL      
   /// RIGHTS RESERVED
   /// </copyright>
   public class MyProjectDto
   {
      public int? ProjectId { get; set; }
      public string ProjectNumber { get; set; }
      public string ProjectName { get; set; }
      public DateTime? StatusDate { get; set; }
      public string Status { get; set; }
   }
}
