using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cts.Venture.Dto;
using Cts.Venture.Data;
using Cts.Venture.Domain;
using Cts.Venture.Common.PaginateList;
using Cts.Venture.Common;

namespace Cts.Venture.Service
{
   /// <summary>This class contains a method for returning a paged list of a user's project tracking items.</summary>
   /// <author>Powers Wartman</author>
   /// <date>September 21, 2016</date>
   /// <copyright> 
   /// Copyright (c) 2016 Computer Technology Solutions, Inc.  ALL      
   /// RIGHTS RESERVED
   /// </copyright>
   public class ProjectTrackingItemsService : BaseService
   {
      /// <summary>
      /// Constructor for db connection.
      /// </summary>
      /// <param name="ctx"></param>
      public ProjectTrackingItemsService(Context ctx) : base(ctx.DbContext)
      {
      }

      /// <summary>This method returns a paged list of project tracking items associated with a user.</summary>
      /// <author>Powers Wartman</author>
      /// <date>September 21, 2016</date>
      /// <exceptions></exceptions>
      /// <param name="user">An integer representing a user Id</param>
      /// <param name="pageNumber">The page number to start the paged list on.</param>
      /// <param name="pageSize">How many records to put on each page.</param>
      /// <param name="sort">The sorting rules for the list.</param>
      /// <param name="order">The ordering rules for the list</param>
      /// <param name="filter">Filters for the list</param>
      /// <return>Return an IPagedList for the ViewToday page.</return>
      /// <history>
      /// Date     Author          Change Reason     Change Description
      /// ----------------------------------------------------------------
      /// 9/21/16  Powers Wartman  Created
      /// ----------------------------------------------------------------
      /// </history>
      public IPagedList<ProjectTrackingItemDto> GetProjectTrackingItems(int user, int pageNumber, int pageSize, string sort, string order, string filter)
      {
         CheckIssue checkissue = new CheckIssue();
         //List<ProjectTrackingItemDto> validlist = new List<ProjectTrackingItemDto>();

         var issueDtolist = Db.Issues.AsNoTracking()
                          .Where(i => i.ProjectTeam.ResourceId == user
                          && i.IssueStatu.IssueStatus == "Open")
                          .Select(x => new ProjectTrackingItemDto
                          {
                             IssueId = x.IssueId
                             ,
                             ProjectId = x.ProjectTeam.ProjectId
                             ,
                             ProjectName = x.ProjectTeam.Project.ProjectName
                             ,
                             IdNumber = x.IssueNumber
                             ,
                             Type = x.IssueType.IssueType_
                             ,
                             Issue = x.Issue_
                             ,
                             AssignedTo = x.ProjectTeam.Resource.Resource_
                             ,
                             NextAction = x.NextAction
                             ,
                             TargetDate = x.TargetDate
                             ,
                             IssueStatus = x.IssueStatu.IssueStatus
                          });

         //issueDtolist = issueDtolist.Where(z => checkissue.IsOverDue(z.TargetDate) == true
         //                 || checkissue.IsUpcoming(z.TargetDate) == true);

         if (string.IsNullOrEmpty(sort))
         {
            return issueDtolist.ToPagedList<ProjectTrackingItemDto>(filter, "ProjectName", order, pageNumber, pageSize);
         } else
         {
            return issueDtolist.ToPagedList<ProjectTrackingItemDto>(filter, sort, order, pageNumber, pageSize); ;
         }


      }
   }
}
