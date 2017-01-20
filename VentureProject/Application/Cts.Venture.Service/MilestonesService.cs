using Cts.Venture.Domain;
using Cts.Venture.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cts.Venture.Service
{
   /// <summary>This class contains a method for finding milestonedto's.</summary>
   /// <author>Powers Wartman</author>
   /// <date>September 21, 2016</date>
   /// <copyright> 
   /// Copyright (c) 2016 Computer Technology Solutions, Inc.  ALL      
   /// RIGHTS RESERVED
   /// </copyright>
   public class MilestonesService : BaseService
   {
      /// <summary>
      /// Constructor for db context.
      /// </summary>
      /// <param name="ctx"></param>
      public MilestonesService(Context ctx) : base(ctx.DbContext)
      {
      }

      /// <summary>This methodis used to fill a table on the view today page.</summary>
      /// <author>Powers Wartman</author>
      /// <date>September 21, 2016</date>
      /// <exceptions></exceptions>
      /// <param name="user">An int representing the user Id.</param>
      /// <return>Return a list of MilestoneDto's associated with a user.</return>
      /// <history>
      /// Date     Author          Change Reason     Change Description
      /// ----------------------------------------------------------------
      /// 9/21/16  Powers Wartman  Created
      /// ----------------------------------------------------------------
      /// </history> 
      public List<MilestoneDto> GetUpcomingMileStones(int user)
      {
         CheckProjectMilestones milesCheck = new CheckProjectMilestones();
         //instantiate the lists
         List<MilestoneDto> milestoneDtolist = new List<MilestoneDto>();

         milestoneDtolist = (from pt in Db.ProjectTeams
              join pm in Db.ProjectStandardMilestones
              on pt.ProjectId
              equals pm.ProjectId
              where pt.ResourceId == user
              select new MilestoneDto
              {
                 ProjectId = pm.ProjectId
               ,
                 Project = pm.Project.ProjectName
               ,
                 Milestone = pm.StandardMilestone.StandardMilestone_
               ,
                 BaselineStart = pm.BaselineStart
               ,
                 BaselineFinish = pm.BaselineFinish
               ,
                 ActualStart = pm.ActualStart
               ,
                 ActualFinish = pm.ActualFinish
               ,
                 PercentComplete = pm.PercentComplete
              }).ToList();

         milestoneDtolist
            .AddRange(from pt in Db.ProjectTeams
                        join pm in Db.ProjectMilestones
                        on pt.ProjectId
                        equals pm.ProjectId
                        where pt.ResourceId == user
                        select new MilestoneDto
                        {
                           Project = pm.Project.ProjectName
                         ,
                           Milestone = pm.Milestone
                         ,
                           BaselineStart = pm.BaselineStart
                         ,
                           BaselineFinish = pm.BaselineFinish
                         ,
                           ActualStart = pm.ActualStart
                         ,
                           ActualFinish = pm.ActualFinish
                         ,
                           PercentComplete = pm.PercentComplete
                        });

         milestoneDtolist = milestoneDtolist
                              .Where(x => milesCheck.IsOverDue(x.BaselineFinish) == true
                              || milesCheck.IsUpcoming(x.BaselineFinish) == true).ToList();

         //return the list
         return milestoneDtolist;
      }
   }
}
