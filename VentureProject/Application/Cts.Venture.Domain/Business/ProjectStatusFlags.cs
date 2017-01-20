using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cts.Venture.Domain
{
   /// <summary>This class is used to set the status flags for search results on the View Today page.</summary>
   /// <author>Powers Wartman</author>
   /// <date>September 21, 2016</date>
   /// <copyright> 
   /// Copyright (c) 2016 Computer Technology Solutions, Inc.  ALL      
   /// RIGHTS RESERVED
   /// </copyright>
   public class ProjectStatusFlags
   {
      /// <summary>This method receives a datetime and returns a string equivalent of a color. This is used to set an element on the page to display an icon.</summary>
      /// <author>Powers Wartman</author>
      /// <date>September 21, 2016</date>
      /// <return>One of three string results matching the possible colors used for icon generation.</return>
      /// <param name="statusdate">A nullable datetime</param>
      /// <history>
      /// Date    Author          Change Reason     Change Description
      /// ----------------------------------------------------------------
      /// 9/21/16 Powers Wartman  Created              
      /// ----------------------------------------------------------------
      /// </history>
      public string StatusColor(DateTime? statusdate)
      {
         if (statusdate != null)
         {
            int datedifference = (DateTime.Now - statusdate.Value).Days;

            if (datedifference <= 7)
            {
               return "green";
            }
            else if (datedifference >= 8 && datedifference < 14)
            {
               return "yellow";
            }
            else
            {
               return "red";
            }
         }
         else
         {
            return null;
         }
      }
   }
}