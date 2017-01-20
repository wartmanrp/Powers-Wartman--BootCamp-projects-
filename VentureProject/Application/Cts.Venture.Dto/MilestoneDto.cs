using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cts.Venture.Dto
{
   /// <summary>This class represents all of the data for a milestone as used on the ViewToday page.</summary>
   /// <author>Powers Wartman</author>
   /// <date>September 21, 2016</date>
   /// <copyright> 
   /// Copyright (c) 2016 Computer Technology Solutions, Inc.  ALL      
   /// RIGHTS RESERVED
   /// </copyright>
   public class MilestoneDto
   {
      public int? ProjectId { get; set; }
      public string Project { get; set; } //project name
      public string Milestone { get; set; }
      public DateTime? BaselineStart { get; set; }
      public DateTime? BaselineFinish { get; set; }
      public DateTime? ActualStart { get; set; }
      public DateTime? ActualFinish { get; set; }
      public decimal? PercentComplete { get; set; }
   }
}
