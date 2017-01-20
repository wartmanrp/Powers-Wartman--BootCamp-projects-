using Cts.Venture.Domain;
using Cts.Venture.Domain.Business;
using Cts.Venture.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
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
   public class ProjectMaintenanceService : BaseService
   {
      /// <summary>
      /// Constructor for db context
      /// </summary>
      /// <param name="ctx"></param>
      public  ProjectMaintenanceService(Context ctx) : base(ctx.DbContext)
      {
      }

      /// <summary>Creates a dto for projectdetails partial</summary>
      /// <author>Powers Wartman</author>
      /// <date>September 21, 2016</date>
      /// <exceptions></exceptions>
      /// <param name="id">A nullable int for project id</param>
      /// <return>Return a dto with dropdowns and detail information.</return>
      /// <history>
      /// Date     Author          Change Reason     Change Description
      /// ----------------------------------------------------------------
      /// 9/21/16  Powers Wartman  Created
      /// ----------------------------------------------------------------
      /// </history> 
      public ProjectDetailsDto GetProjectDetails(int? id)
      {
         GetPercentComplete percent = new GetPercentComplete();
         ProjectDetailsDto dto = null;
         if (id > 0)
         {
            var iqProject = Db.Projects
               .Where(x => x.ProjectId == id)
               .Select(n => new ProjectDetailsDto
               {
                  ProjectId = n.ProjectId
                  ,
                  ProjectNumber = n.ProjectNumber
                  ,
                  ProjectName = n.ProjectName
                  ,
                  ProjectStatus = n.Indicator.Status.Status_
                  ,
                  AddToWatchList = (bool)n.Watchlist
                  ,
                  ProjectGoalId = n.ProjectGoalId
                  ,
                  ProjectLevelId = n.ProjectLevelId
                  ,
                  ProjectIndicatorId = n.IndicatorId
                  ,
                  LobId = n.Lobid
                  ,
                  DepartmentId = n.DepartmentId
                  ,
                  BusinessIssue = n.BusinessIssue
                  ,
                  Solution = n.Solution
                  ,
                  Benefits = n.Benefits
                  ,
                  ProjectDirectory = n.ProjectDirectory
                  ,
                  ProjectSeqNumber = n.ProjectSeqNumber

               });

            dto = iqProject.Single();
         }
         else
         {
            dto = new ProjectDetailsDto();
         }

         dto.ProjectGoalsList = Db.ProjectGoals
               .Select(p => new ProjectGoalDto
               {
                  ProjectGoalId = p.ProjectGoalId
                  ,
                  ProjectGoal_ = p.ProjectGoal_
               }).ToList();

         dto.ProjectLevelsList = Db.ProjectLevels
            .Select(l => new ProjectLevelDto
            {
               ProjectLevelId = l.ProjectLevelId
               ,
               ProjectLevel = l.ProjectLevel_
            }).ToList();

         dto.IndicatorsList = Db.Indicators
            .Select(i => new IndicatorDto
            {
               IndicatorId = i.IndicatorId
               ,
               ProjectIndicator = i.ProjectIndicator
               ,
               SortNumber = i.SortNumber
               ,
               StatusId = i.ProjectStatusId
            }).ToList();

         dto.LobsList = Db.Lobs
            .Where(l => !l.Deleted)
            .Select(l => new LobDto
            {
               LobId = l.Lobid
               ,
               Lob = l.Lob_
            }).ToList();

         dto.DepartmentsList = Db.Departments
            .Where(d => !d.Deleted)
            .Select(d => new DepartmentDto
            {
               DepartmentId = d.DepartmentId
               ,
               Department = d.Department_
            }).ToList();

         //this section gets milestones data for proj. completion method in domain layer
         var milestonesList = Db.ProjectStandardMilestones
                              .Where(psm => psm.ProjectId == id).Select(psm => psm.PercentComplete).ToArray();

         dto.ProjectCompletion = percent.CalculateProjectCompletion(id, milestonesList);
         //CalculateProjectCompletion(id);

         return dto;
      }

      /// <summary>Saves or edits a project</summary>
      /// <author>Powers Wartman</author>
      /// <date>September 21, 2016</date>
      /// <exceptions></exceptions>
      /// <param name="dto">A project details dto</param>
      /// <return>Return an integer used for redirection.</return>
      /// <history>
      /// Date     Author          Change Reason     Change Description
      /// ----------------------------------------------------------------
      /// 9/21/16  Powers Wartman  Created
      /// ----------------------------------------------------------------
      /// </history> 
      //SAVE Save or Edit Project
      public int SaveProject(ProjectDetailsDto dto)
      {
         GenerateNewProjectNumber newProjectNumber = new GenerateNewProjectNumber();
         Project project = new Project();
         
         if (dto.ProjectId > 0)
         {
            project.ProjectId = dto.ProjectId;
            Db.Projects.Attach(project);
         }
         else
         {
            Db.Projects.Add(project);
         }
            project.ProjectName = dto.ProjectName;

            project.Watchlist = dto.AddToWatchList;
            project.BusinessIssue = dto.BusinessIssue;
            project.Solution = dto.Solution;
            project.Benefits = dto.Benefits;
            project.ProjectDirectory = dto.ProjectDirectory;
            project.DepartmentId = dto.DepartmentId;
            project.ProjectGoalId = dto.ProjectGoalId; 
            project.ProjectLevelId = dto.ProjectLevelId;
            project.Lobid = dto.LobId;
            project.IndicatorId = dto.ProjectIndicatorId;

         if (dto.ProjectNumber != null)
         {
            project.ProjectNumber = dto.ProjectNumber;
         }
         else
         {
            project.ProjectNumber = GetNewProjectNumber();
         }

         Db.SaveChanges();

         return project.ProjectId;
      }

      /// <summary>Generates a new project number.</summary>
      /// <author>Powers Wartman</author>
      /// <date>September 21, 2016</date>
      /// <exceptions></exceptions>
      /// <return>Returns a string used for assigning a new project number.</return>
      /// <history>
      /// Date     Author          Change Reason     Change Description
      /// ----------------------------------------------------------------
      /// 9/21/16  Powers Wartman  Created
      /// ----------------------------------------------------------------
      /// </history> 
      private string GetNewProjectNumber()
      {
         try
         {
            int sequence = Db.Projects
               .Where(p => p.ProjectYear == DateTime.Now.Year)
               .Max(p => p.ProjectSeqNumber) + 1;
            string year = DateTime.Now.Year.ToString();
            string projnumber = year + "-" + sequence.ToString();
            return projnumber;
         }
         catch (InvalidOperationException)
         {
            int sequence = 1; 
            string year = DateTime.Now.Year.ToString();
            string projnumber = year + "-" + sequence.ToString();
            
            return projnumber;
         }
      }
   }
}
