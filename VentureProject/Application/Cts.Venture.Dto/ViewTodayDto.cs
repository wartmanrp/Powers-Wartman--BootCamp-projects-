using Cts.Venture.Common.PaginateList;
using Cts.Venture.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cts.Venture.Dto
{
   /// <summary>This class represents the data used for the Index view of View Today.</summary>
   /// <author>Powers Wartman</author>
   /// <date>September 21, 2016</date>
   /// <copyright> 
   /// Copyright (c) 2016 Computer Technology Solutions, Inc.  ALL      
   /// RIGHTS RESERVED
   /// </copyright>
   public class ViewTodayDto
   {
      public UserDto User { get; set; }
      public IPagedList<ProjectTrackingItemDto> ProjectTrackingItems { get; set; }
      public List<MilestoneDto> UpcomingMilestones { get; set; }

   }
}
