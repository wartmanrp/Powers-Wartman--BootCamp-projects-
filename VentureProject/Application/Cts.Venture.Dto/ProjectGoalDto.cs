using Cts.Venture.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cts.Venture.Dto
{
   /// <summary>This class represents options for a dropdown list.</summary>
   /// <author>Powers Wartman</author>
   /// <date>September 21, 2016</date>
   /// <copyright> 
   /// Copyright (c) 2016 Computer Technology Solutions, Inc.  ALL      
   /// RIGHTS RESERVED
   /// </copyright>
   public class ProjectGoalDto : ILookup
   {
      public int ProjectGoalId { get; set; }
      public string ProjectGoal_ { get; set; }
      public string DataText
      {
         get
         {
            return ProjectGoal_.ToString();
         }
      }

      public string DataValue
      {
         get
         {
            return ProjectGoalId.ToString();
         }
      }

   }
}
