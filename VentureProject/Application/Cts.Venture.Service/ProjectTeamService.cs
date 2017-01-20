using Cts.Venture.Domain;
using Cts.Venture.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cts.Venture.Service
{
   /// <summary>This class contains methods pertaining to the management of project teams. Index, modification, creation and deletion.</summary>
   /// <author>Powers Wartman</author>
   /// <date>September 21, 2016</date>
   /// <copyright> 
   /// Copyright (c) 2016 Computer Technology Solutions, Inc.  ALL      
   /// RIGHTS RESERVED
   /// </copyright>

   public class ProjectTeamService : BaseService
   {
      /// <summary>
      /// Constructor for the db context.
      /// </summary>
      /// <param name="ctx"></param>
      public ProjectTeamService(Context ctx) : base(ctx.DbContext)
      {
      }

      /// <summary>Creates a dto for projectteamdetails partial</summary>
      /// <author>Powers Wartman</author>
      /// <date>September 21, 2016</date>
      /// <exceptions></exceptions>
      /// <param name="projId">A nullable int for project id</param>
      /// <return>Return a dto with dropdowns and a table.</return>
      /// <history>
      /// Date     Author          Change Reason     Change Description
      /// ----------------------------------------------------------------
      /// 9/21/16  Powers Wartman  Created
      /// ----------------------------------------------------------------
      /// </history>     
      public ProjectTeamDetailsDto GetProjectTeamDetailsDto(int? projId)
      {
         ProjectTeamDetailsDto dto = new ProjectTeamDetailsDto();
         if (projId > 0)
         {
            dto.ProjectResources = GetResources(projId);
            dto.ProjectTeams = GetTeams(projId);
         } else
         {
            dto = new ProjectTeamDetailsDto();
         }

         dto.RolesList = GetRolesList();

         dto.ResourcesList = GetResourcesList();

         return dto;
      }

      /// <summary>Builds of list of all available resources</summary>
      /// <author>Powers Wartman</author>
      /// <date>September 21, 2016</date>
      /// <exceptions></exceptions>
      /// <return>Return a list of resources</return>
      /// <history>
      /// Date     Author          Change Reason     Change Description
      /// ----------------------------------------------------------------
      /// 9/21/16  Powers Wartman  Created
      /// ----------------------------------------------------------------
      /// </history>     
      public List<ResourceLookupDto> GetResourcesList()
      {
         List<ResourceLookupDto> resourceList = Db.Resources
                             .Select(r => new ResourceLookupDto
                             {
                                ResourceId = r.ResourceId
                                ,
                                Resource = r.Resource_
                                ,
                                Email = r.Email
                                ,
                                Phone = r.Phone
                             }).ToList();

         return resourceList;
      }

      /// <summary>Builds of list of all available roles</summary>
      /// <author>Powers Wartman</author>
      /// <date>September 21, 2016</date>
      /// <exceptions></exceptions>
      /// <return>Return a list of roles</return>
      /// <history>
      /// Date     Author          Change Reason     Change Description
      /// ----------------------------------------------------------------
      /// 9/21/16  Powers Wartman  Created
      /// ----------------------------------------------------------------
      /// </history>    
      public List<TeamRoleDto> GetRolesList()
      {
         List<TeamRoleDto> rolesList = Db.TeamRoles
                        .Select(tr => new TeamRoleDto
                        {
                           TeamRoleId = tr.TeamRoleId
                           ,
                           TeamRole = tr.TeamRole_
                        }).ToList();

         return rolesList;
      }


      /// <summary>Builds a list of all project teams on a project</summary>
      /// <author>Powers Wartman</author>
      /// <date>September 21, 2016</date>
      /// <exceptions></exceptions>
      /// <param name="projId">A nullable int for project id</param>
      /// <return>Return a list of project team dtos associated with a project</return>
      /// <history>
      /// Date     Author          Change Reason     Change Description
      /// ----------------------------------------------------------------
      /// 9/21/16  Powers Wartman  Created
      /// ----------------------------------------------------------------
      /// </history>    
      public List<ProjectTeamDto> GetTeams(int? projId)
      {
         List<ProjectTeamDto> teamsList = new List<ProjectTeamDto>();
         try
         {
            teamsList = Db.ProjectTeams
                        .Where(pt => !pt.Deleted)
                        .Where(pt => pt.ProjectId == projId)
                        .Select(n => new ProjectTeamDto
                        {
                           ResourceId = n.ResourceId
                           ,
                           ProjectId = n.Project.ProjectId
                           ,
                           ProjectTeamId = n.ProjectTeamId
                           ,
                           Role = n.ProjectTeamRoles.FirstOrDefault(t => t.ProjectTeamId == n.ProjectTeamId).TeamRole.TeamRole_
                           ,
                           RoleId = n.ProjectTeamRoles.FirstOrDefault(t => t.ProjectTeamId == n.ProjectTeamId).TeamRole.TeamRoleId
                           ,
                           ProjectTeamRoleId = n.ProjectTeamRoles.FirstOrDefault(r => r.ProjectTeamId == n.ProjectTeamId).ProjectTeamRoleId
                           ,
                           Email = n.Resource.Email
                           ,
                           Phone = n.Resource.Phone
                           ,
                           Resource = n.Resource.Resource_
                        }).ToList();

            return teamsList;
         }
         catch (NullReferenceException)
         {
            return null;
         }
      }

      /// <summary>Builds a list of all resources on a project</summary>
      /// <author>Powers Wartman</author>
      /// <date>September 21, 2016</date>
      /// <exceptions></exceptions>
      /// <param name="projId">A nullable int for project id</param>
      /// <return>Return a list of resource dtos associated with a project</return>
      /// <history>
      /// Date     Author          Change Reason     Change Description
      /// ----------------------------------------------------------------
      /// 9/21/16  Powers Wartman  Created
      /// ----------------------------------------------------------------
      /// </history>    
      public List<ResourceDto> GetResources(int? projId)
      {
         List<ResourceDto> resourceList = new List<ResourceDto>();
         try
         {
            resourceList = Db.ProjectTeams
                        .Where(r => !r.Deleted)
                        .Where(r => r.ProjectId == projId)
                        .Select(x => new ResourceDto
                        {
                           ResourceId = x.ResourceId
                           ,
                           Resource = x.Resource.Resource_
                           ,
                           Email = x.Resource.Email
                           ,
                           Phone = x.Resource.Phone
                        })
                        .ToList();

            return resourceList;
         }
         catch (Exception)
         {
            return null;
         }
      }

      /// <summary>Saves a new projectteam or edits existing</summary>
      /// <author>Powers Wartman</author>
      /// <date>September 21, 2016</date>
      /// <exceptions></exceptions>
      /// <param name="dto">A project team dto for saving/editing</param>
      /// <return>Void</return>
      /// <history>
      /// Date     Author          Change Reason     Change Description
      /// ----------------------------------------------------------------
      /// 9/21/16  Powers Wartman  Created
      /// ----------------------------------------------------------------
      /// </history>    
      public void SaveProjectTeam(ProjectTeamDto dto)
      {
         ProjectTeam team = new ProjectTeam();
         team.ProjectTeamId = dto.ProjectTeamId;

         if(dto.ProjectTeamId > 0)
         {
            Db.ProjectTeams.Attach(team);
         }
         else
         {
            Db.ProjectTeams.Add(team);
         }

         team.ProjectTeamId = dto.ProjectTeamId;
         team.ResourceId = dto.ResourceId;
         team.ProjectId = dto.ProjectId;


         Db.SaveChanges();

         AddNewProjectTeamRole(dto, team.ProjectTeamId);
         //this might not work, may need async
         //return dto.ProjectId;
      }

      /// <summary>Saves a new projectteamrole or edits existing</summary>
      /// <author>Powers Wartman</author>
      /// <date>September 21, 2016</date>
      /// <exceptions></exceptions>
      /// <param name="dto">A project team dto for saving/editing</param>
      /// <param name="teamId">A project team id for saving/editing</param>
      /// <return>Void</return>
      /// <history>
      /// Date     Author          Change Reason     Change Description
      /// ----------------------------------------------------------------
      /// 9/21/16  Powers Wartman  Created
      /// ----------------------------------------------------------------
      /// </history>    
      public void AddNewProjectTeamRole(ProjectTeamDto dto, int teamId)
      {
         ProjectTeamRole teamRole = new ProjectTeamRole();
         teamRole.ProjectTeamRoleId = dto.ProjectTeamRoleId;

         if (dto.ProjectTeamRoleId > 0)
         {
            Db.ProjectTeamRoles.Attach(teamRole);
         }
         else
         {
            Db.ProjectTeamRoles.Add(teamRole);
         }

         teamRole.ProjectTeamId = teamId;
         teamRole.TeamRoleId = dto.RoleId;

         Db.SaveChanges();
      }

      /// <summary>Deletes a projectteam or marks it as deleted</summary>
      /// <author>Powers Wartman</author>
      /// <date>September 21, 2016</date>
      /// <exceptions></exceptions>
      /// <param name="projTeamId">A project team id for deletion</param>
      /// <return>Void</return>
      /// <history>
      /// Date     Author          Change Reason     Change Description
      /// ----------------------------------------------------------------
      /// 9/21/16  Powers Wartman  Created
      /// ----------------------------------------------------------------
      /// </history> 
      public void RemoveProjectTeam(int projTeamId)
      {
         var team = Db.ProjectTeams
            .FirstOrDefault(t => t.ProjectTeamId == projTeamId);
         team.Deleted = true;
         Db.SaveChanges();

         Db.ProjectTeams.Remove(team);
         try
         {
            Db.SaveChanges();
         }
         catch (DbUpdateException)
         {
          
         }

      }
   }
}
