using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cts.Venture.Domain.Business
{
   /// <summary>This class allows a project to calculate its completion percentage.</summary>
   /// <author>Powers Wartman</author>
   /// <date>September 21, 2016</date>
   /// <copyright> 
   /// Copyright (c) 2016 Computer Technology Solutions, Inc.  ALL      
   /// RIGHTS RESERVED
   /// </copyright>
   public class GetPercentComplete
    {
      /// <summary>This method takes a project id and an array of decimals to calculate the project completion percentage for a project.</summary>
      /// <author>Powers Wartman</author>
      /// <date>September 21, 2016</date>
      /// <exceptions>InvalidOperationException is possible.</exceptions>
      /// <return>A nullable decimal which will always equal at least 0.</return>
      /// <param name="projId">A projectId used simply to determine if the percent complete is being assigned to an existing project or not.</param>
      /// <param name="milestonesList">An array of decimal?'s generated in the service method. These are parsed and factored to determine the return value.</param>
      /// <history>
      /// Date    Author          Change Reason     Change Description
      /// ----------------------------------------------------------------
      /// 9/21/16 Powers Wartman  Created              
      /// ----------------------------------------------------------------
      /// </history>
      public decimal? CalculateProjectCompletion(int? projId, decimal?[] milestonesList)
      {
         decimal? percentComplete = 0;
         if (projId > 0)
         {
            try
            {
               foreach (var item in milestonesList)
               {
                  if (item != null)
                  {
                     percentComplete += ((item / 100) * (100 / milestonesList.Count()));
                  };
               }
               return percentComplete;
            }
            catch (InvalidOperationException)
            {
               return percentComplete;
            }
         }
         else
         {
            return percentComplete;
         }
      }

   }
}
