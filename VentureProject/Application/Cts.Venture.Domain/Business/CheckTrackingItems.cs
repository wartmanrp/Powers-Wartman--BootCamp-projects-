using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cts.Venture.Domain
{
   /// <summary>This business rule is used to determine if a project tracking
   /// item meets the conditions to be considered "upcoming" or "overdue"
   /// </summary>
   /// <author>Powers Wartman</author>
   /// <date>September 21, 2016</date>
   /// <copyright> 
   /// Copyright (c) 2016 Computer Technology Solutions, Inc.  ALL      
   /// RIGHTS RESERVED
   /// </copyright>
   public class CheckIssue
   {
      /// <summary>This method returns a bool to determine if an item is upcoming.</summary>
      /// <param name="TargetDate">A nullable datetime to check against</param>
      /// <returns>Boolean result regardless of whether param is null</returns>
      /// <history>
      /// Date    Author          Change Reason     Change Description
      /// ----------------------------------------------------------------
      /// 9/21/16 Powers Wartman  Created              
      /// ----------------------------------------------------------------
      /// </history>
      public bool IsUpcoming (DateTime? TargetDate)
      {
         if (TargetDate.HasValue)
         {
            int finish = (TargetDate.Value - DateTime.Now).Days;
            if (finish <= 7)
            {
               return true;
            }
            else
            {
               return false;
            }
         }
         else
         {
            return false;
         }
      }

      /// <summary>This method returns a bool to determine if an item is upcoming.</summary>
      /// <param name="TargetDate">A nullable datetime to check against</param>
      /// <returns>Boolean result regardless of whether param is null</returns>
      /// <history>
      /// Date    Author          Change Reason     Change Description
      /// ----------------------------------------------------------------
      /// 9/21/16 Powers Wartman  Created              
      /// ----------------------------------------------------------------
      /// </history>
      public bool IsOverDue (DateTime? TargetDate)
      {
         if (TargetDate.HasValue)
         {
            int overdue = (TargetDate.Value - DateTime.Now).Days;
            if (overdue < 0)
            {
               return true;
            }
            else
            {
               return false;
            }
         }
         else
         {
            return false;
         }
      }
   }
}
