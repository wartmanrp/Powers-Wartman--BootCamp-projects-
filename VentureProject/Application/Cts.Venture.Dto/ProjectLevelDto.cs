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
   public class ProjectLevelDto : ILookup
   {
      public int ProjectLevelId { get; set; }
      public string ProjectLevel { get; set; }

      public string DataValue
      {
         get
         {
            return ProjectLevelId.ToString();
         }
      }

      public string DataText
      {
         get
         {
            return ProjectLevel.ToString();
         }
      }
   }
}
