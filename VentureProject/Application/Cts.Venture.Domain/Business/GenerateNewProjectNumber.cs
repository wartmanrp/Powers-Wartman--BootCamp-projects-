using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cts.Venture.Domain
{
   /// <summary>This class contains methods pertaining to generating
   /// a new project number when a new project is saved to 
   /// the db.
   /// </summary>
   /// <author>Powers Wartman</author>
   /// <date>September 21, 2016</date>
   /// <copyright> 
   /// Copyright (c) 2016 Computer Technology Solutions, Inc.  ALL      
   /// RIGHTS RESERVED
   /// </copyright>
   public class GenerateNewProjectNumber
   {
      /// <summary>
      /// This method will be passed a string of the most 
      /// recent sequence number, it will then parse the 
      /// string into an int and build a new string to 
      /// generate a new project number.
      /// </summary>
      /// <param name="lastsequence">A non nullable integer related to the project
      /// being queried</param>
      /// <returns>A string formed through concatenating the param and the current year
      /// </returns>
      /// <history>
      /// Date    Author          Change Reason     Change Description
      /// ----------------------------------------------------------------
      /// 9/21/16 Powers Wartman  Created              
      /// ----------------------------------------------------------------
      /// </history>
      public string NewProjectNumber(int lastsequence)
      {
         var currentyear = DateTime.Now.Year;
         string NewNumber = currentyear.ToString() + "-" + (lastsequence + 1).ToString();
         return NewNumber;
      }
   }
}
