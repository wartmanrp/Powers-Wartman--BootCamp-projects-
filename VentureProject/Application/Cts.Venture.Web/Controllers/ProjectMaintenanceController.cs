using Cts.Venture.Dto;
using Cts.Venture.Service;
using Cts.Venture.Web.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cts.Venture.Web.Controllers
{
   /// <summary>This class acts as the controller for all project maintenance functions, such as saving and editing a project or project team.</summary>
   /// <author>Powers Wartman</author>
   /// <date>October 17, 2016</date>
   /// <copyright> 
   /// Copyright (c) 2016 Computer Technology Solutions, Inc.  ALL      
   /// RIGHTS RESERVED
   /// </copyright>
   public class ProjectMaintenanceController : BaseController
    {
      /// <summary>This function returns the view for a specific project. If it is null, it will come back as an empty project for the creation of a new record</summary>
      /// <author>Powers Wartman</author>
      /// <date>October 17, 2016</date>
      /// <return>Returns a View containing the model desired.</return>
      /// <param name="project">A project Id</param>
      /// <history>
      /// Date              Author         Change Reason  Change Description
      /// ----------------------------------------------------------------
      /// October 17, 2016  Powers Wartman   Created       Created method
      /// ----------------------------------------------------------------
      /// </history>
      [HttpGet]
      public ActionResult ProjectMaintenance(int? project)
      {
         ProjectMaintenanceService ProjectService = new ProjectMaintenanceService(ServiceContext);
         
         ProjectDetailsDto model = ProjectService.GetProjectDetails(project);

         return View(model);
      }

      /// <summary>This function saves project details.</summary>
      /// <author>Powers Wartman</author>
      /// <date>October 17, 2016</date>
      /// <return>Returns the user to a view or redirects.</return>
      /// <param name="project">A ProjectDetailsDto</param>
      /// <history>
      /// Date              Author         Change Reason  Change Description
      /// ----------------------------------------------------------------
      /// October 17, 2016  Powers Wartman   Created       Created method
      /// ----------------------------------------------------------------
      /// </history>
      [HttpPost]
      public ActionResult SaveProjectDetails(ProjectDetailsDto project)
      {
         if (ModelState.IsValid)
         {
            ProjectMaintenanceService ProjectService = new ProjectMaintenanceService(ServiceContext);
            int id = ProjectService.SaveProject(project);
            return RedirectToAction("ProjectMaintenance", new { project = id });
         } 
         else
         {
            return View("ProjectMaintenance", project);
         }        
      }

      /// <summary>This function loads the partial containing project details form.</summary>
      /// <author>Powers Wartman</author>
      /// <date>October 17, 2016</date>
      /// <return>Returns a partial view result.</return>
      /// <param name="id">A projectId number.</param>
      /// <history>
      /// Date              Author         Change Reason  Change Description
      /// ----------------------------------------------------------------
      /// October 17, 2016  Powers Wartman   Created       Created method
      /// ----------------------------------------------------------------
      /// </history>
      [ChildActionOnly]
      public PartialViewResult GetProjectDetailsPartial(int? id)
      {
         try
         {
            ProjectMaintenanceService ProjectService = new ProjectMaintenanceService(ServiceContext);

            ProjectDetailsDto model = ProjectService.GetProjectDetails(id);
         
            return PartialView("_ProjectDetailsPartial", model);

         }
         catch (Exception)
         {
            return PartialView("_ErrorPartial");
         }
      }

      /// <summary>This function loads the partial containing project team details for a project</summary>
      /// <author>Powers Wartman</author>
      /// <date>October 17, 2016</date>
      /// <return>Returns a partial view result.</return>
      /// <param name="id">A projectId number.</param>
      /// <history>
      /// Date              Author         Change Reason  Change Description
      /// ----------------------------------------------------------------
      /// October 17, 2016  Powers Wartman   Created       Created method
      /// ----------------------------------------------------------------
      /// </history>
      [ChildActionOnly]
      public PartialViewResult GetProjectTeamPartial(int? id)
      {
         if(id != null)
         {
            ProjectTeamService teamService = new ProjectTeamService(ServiceContext);
            ProjectMaintenanceService projService = new ProjectMaintenanceService(ServiceContext);

            ProjectTeamDetailsDto model = teamService.GetProjectTeamDetailsDto(id);
            model.Project = projService.GetProjectDetails(id);

            return PartialView("_ProjectTeamPartial", model);
         }
         else
         {
            return PartialView("_ProjectTeamPartial", null);
         }
      }

      /// <summary>This function loads the partial for adding a new project team record.</summary>
      /// <author>Powers Wartman</author>
      /// <date>October 17, 2016</date>
      /// <return>Returns a partial view result.</return>
      /// <param name="projId">A project Id</param>
      /// <history>
      /// Date              Author         Change Reason  Change Description
      /// ----------------------------------------------------------------
      /// October 17, 2016  Powers Wartman   Created       Created method
      /// ----------------------------------------------------------------
      /// </history>
      [ChildActionOnly]
      public PartialViewResult GetAddTeamPartial(int? projId)
      {
         ProjectTeamService teamService = new ProjectTeamService(ServiceContext);
         ProjectMaintenanceService projService = new ProjectMaintenanceService(ServiceContext);

         ProjectTeamDetailsDto model = new ProjectTeamDetailsDto();
         model.ResourcesList = teamService.GetResourcesList();
         model.RolesList = teamService.GetRolesList();
         model.Project = projService.GetProjectDetails(projId);
         
         return PartialView("_AddTeamPartial", model);
      }

      /// <summary>This function is invoked via AJAX and adds a new project team record.</summary>
      /// <author>Powers Wartman</author>
      /// <date>October 17, 2016</date>
      /// <return>Returns a partial view result.</return>
      /// <param name="input">A projectTeamDto for adding/updating a project team record.</param>
      /// <history>
      /// Date              Author         Change Reason  Change Description
      /// ----------------------------------------------------------------
      /// October 17, 2016  Powers Wartman   Created       Created method
      /// ----------------------------------------------------------------
      /// </history>
      [HttpPost]
      [AjaxOnly]
      public PartialViewResult AddProjectTeam(ProjectTeamDto input)
      {
         ProjectTeamService teamService = new ProjectTeamService(ServiceContext);
         ProjectMaintenanceService projService = new ProjectMaintenanceService(ServiceContext);
         ProjectTeamDto newTeam = new ProjectTeamDto();

         newTeam.ProjectTeamId = input.ProjectTeamId;
         newTeam.ProjectId = input.ProjectId;
         newTeam.RoleId = input.RoleId;
         newTeam.ResourceId = input.ResourceId;
         newTeam.ProjectTeamRoleId = input.ProjectTeamRoleId;

         teamService.SaveProjectTeam(newTeam);

         ProjectTeamDetailsDto model = new ProjectTeamDetailsDto();

         model.ProjectTeams = teamService.GetTeams(input.ProjectId);
         model.ProjectResources = teamService.GetResources(input.ProjectId);
         model.Project = projService.GetProjectDetails(input.ProjectId);

         return PartialView("_ProjectTeamPartial", model);
      }

      /// <summary>This function is invoked via AJAX and deletes a project team record.</summary>
      /// <author>Powers Wartman</author>
      /// <date>October 17, 2016</date>
      /// <return>Returns a partial view result.</return>
      /// <param name="input">A projectTeamDto for deleting a project team record.</param>
      /// <history>
      /// Date              Author         Change Reason  Change Description
      /// ----------------------------------------------------------------
      /// October 17, 2016  Powers Wartman   Created       Created method
      /// ----------------------------------------------------------------
      /// </history>
      [HttpPost]
      [AjaxOnly]
      public PartialViewResult RemoveProjectTeam(ProjectTeamDto input)
      {
         ProjectTeamService teamService = new ProjectTeamService(ServiceContext);
         ProjectMaintenanceService projService = new ProjectMaintenanceService(ServiceContext);
         ProjectTeamDto newTeam = new ProjectTeamDto();

         teamService.RemoveProjectTeam(input.ProjectTeamId);

         ProjectTeamDetailsDto model = new ProjectTeamDetailsDto();

         model.ProjectTeams = teamService.GetTeams(input.ProjectId);
         model.ProjectResources = teamService.GetResources(input.ProjectId);
         model.Project = projService.GetProjectDetails(input.ProjectId);

         return PartialView("_ProjectTeamPartial", model);
      }
   }
}