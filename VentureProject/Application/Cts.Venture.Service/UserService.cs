using Cts.Venture.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cts.Venture.Service
{
   /// <summary>This class exists simply to instantiate a basic user for testing purposes in the Venture Application</summary>
   /// <author>Powers Wartman</author>
   /// <date>September 21, 2016</date>
   /// <copyright> 
   /// Copyright (c) 2016 Computer Technology Solutions, Inc.  ALL      
   /// RIGHTS RESERVED
   /// </copyright>
   public class UserService :  BaseService
   {
      /// <summary>
      /// Constructor for db connection.
      /// </summary>
      /// <param name="ctx"></param>
      public UserService(Context ctx) : base(ctx.DbContext)
      {
      }

      /// <summary>This method returns a vasic user object for testing purposes</summary>
      /// <author>Powers Wartman</author>
      /// <date>September 21, 2016</date>
      /// <exceptions></exceptions>
      /// <return>Return a hard-coded UserDto</return>
      /// <history>
      /// Date     Author          Change Reason     Change Description
      /// ----------------------------------------------------------------
      /// 9/21/16  Powers Wartman  Created
      /// ----------------------------------------------------------------
      /// </history>
      public UserDto GetUser ()
      {
         //grab the user
         //var userId = 5; //Db.Resources.FirstOrDefault(u => u.Resource_ == name);
         //var userEmai

         //make the dto
         UserDto user = new UserDto();

         //fill the dto
         user.ResourceId = 5;//currentuser.ResourceId;
         user.Name = "Ron Swanson";//currentuser.Resource_;
         user.Email = "Ron@no.gov";//currentuser.Email;
         user.Phone = "1234567890";//currentuser.Phone;
         user.UserId = "5";//currentuser.UserId;

         //return
         return user;
      }
   }
}
