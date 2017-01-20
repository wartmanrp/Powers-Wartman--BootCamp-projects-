using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cts.Venture.Dto
{
   /// <summary>This class represents a typical user of the Venture Application</summary>
   /// <author>Powers Wartman</author>
   /// <date>September 21, 2016</date>
   /// <copyright> 
   /// Copyright (c) 2016 Computer Technology Solutions, Inc.  ALL      
   /// RIGHTS RESERVED
   /// </copyright>
   public class UserDto
   {
      public int ResourceId { get; set; }
      public string Name { get; set; }
      public string Email { get; set; }
      public string Phone { get; set; }
      public string UserId { get; set; }
   }
}
