using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cts.Venture.Dto
{
   /// <summary>This class represents a project tracking item to be viewed on the View Today page. </summary>
   /// <author>Powers Wartman</author>
   /// <date>September 21, 2016</date>
   /// <copyright> 
   /// Copyright (c) 2016 Computer Technology Solutions, Inc.  ALL      
   /// RIGHTS RESERVED
   /// </copyright>
   public class ProjectTrackingItemDto
   {
      public int IssueId { get; set; }
      public int? ProjectId { get; set; }
      public string ProjectName { get; set; }
      public int? IdNumber { get; set; }
      public string Type { get; set; }
      public string Issue { get; set; }
      public string AssignedTo { get; set; }
      public string NextAction { get; set; }
      public DateTime? TargetDate { get; set; }
      public string IssueStatus { get; set; }
   }
}
