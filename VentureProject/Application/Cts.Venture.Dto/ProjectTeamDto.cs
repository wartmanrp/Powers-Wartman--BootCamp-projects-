using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cts.Venture.Dto
{
   /// <summary>This class represents a project team for using on the manage project teams page. It inherits from resourceDto in order to access the members found there.</summary>
   /// <author>Powers Wartman</author>
   /// <date>September 21, 2016</date>
   /// <copyright> 
   /// Copyright (c) 2016 Computer Technology Solutions, Inc.  ALL      
   /// RIGHTS RESERVED
   /// </copyright>
   public class ProjectTeamDto : ResourceDto
   {
      [Required(ErrorMessage ="You must be viewing a valid project in order to add project teams")]
      public int? ProjectId { get; set; }
      public int ProjectTeamId { get; set; }
      public int RoleId { get; set; }
      public int ProjectTeamRoleId { get; set; }
   }
}
