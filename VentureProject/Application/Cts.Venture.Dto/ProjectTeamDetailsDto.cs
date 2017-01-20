using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cts.Venture.Dto
{
   /// <summary>This class represents the data linked to a project for view on the project team details view..</summary>
   /// <author>Powers Wartman</author>
   /// <date>September 21, 2016</date>
   /// <copyright> 
   /// Copyright (c) 2016 Computer Technology Solutions, Inc.  ALL      
   /// RIGHTS RESERVED
   /// </copyright>
   public class ProjectTeamDetailsDto
   {
      public ProjectDetailsDto Project { get; set; }
      public List<ProjectTeamDto> ProjectTeams { get; set; }
      public List<ResourceDto> ProjectResources { get; set; }

      public int? RoleId { get; set; }
      public List<TeamRoleDto> RolesList { get; set; }
      public int? ResourceId { get; set; }
      public List<ResourceLookupDto> ResourcesList { get; set; }
   }
}
