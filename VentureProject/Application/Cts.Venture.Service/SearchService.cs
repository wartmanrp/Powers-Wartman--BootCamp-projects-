using Cts.Venture.Domain;
using Cts.Venture.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cts.Venture.Service
{
   /// <summary>This class contains a method for performing searches.</summary>
   /// <author>Powers Wartman</author>
   /// <date>September 21, 2016</date>
   /// <copyright> 
   /// Copyright (c) 2016 Computer Technology Solutions, Inc.  ALL      
   /// RIGHTS RESERVED
   /// </copyright>
   public class SearchService : BaseService
   {
      /// <summary>
      /// Constructor for db context.
      /// </summary>
      /// <param name="ctx"></param>
      public SearchService(Context ctx) : base(ctx.DbContext)
      {
      }     

      /// <summary>This method returns an Ienumerable of ProjectDto's to fulfill search requests by a user on the view today page..</summary>
      /// <author>Powers Wartman</author>
      /// <date>September 21, 2016</date>
      /// <exceptions></exceptions>
      /// <param name="input">A SearchParamsDto containg the users input.</param>      
      /// <return>Return an IEnumberable of results(MyProjectDto)</return>
      /// <history>
      /// Date     Author          Change Reason     Change Description
      /// ----------------------------------------------------------------
      /// 9/21/16  Powers Wartman  Created
      /// ----------------------------------------------------------------
      /// </history>     
      public IEnumerable<MyProjectDto> SearchByProjectNumber(SearchParamsDto input)
      {
         ProjectStatusFlags FlagColor = new ProjectStatusFlags();

         var projectlist = Db.ProjectTeams.Where(p => p.ResourceId == input.ResourceId).Select(x => x.Project);
               
         if (!string.IsNullOrEmpty(input.ProjectName))
         {
            projectlist = projectlist.Where(p => p.ProjectName.Contains(input.ProjectName));
         }

         //if project number is passed, get those too.
         if (!string.IsNullOrEmpty(input.ProjectNumber))
         {
            projectlist = projectlist.Where(p => p.ProjectNumber.Contains(input.ProjectNumber));
         }

         //check for null and generate dto's
         if (projectlist != null)
         {
            List<MyProjectDto> returnlist = new List<MyProjectDto>();
            ProjectStatusFlags flags = new ProjectStatusFlags();

            foreach(var project in projectlist)
            {
               MyProjectDto proj = new MyProjectDto();
               proj.ProjectId = project.ProjectId;
               proj.ProjectNumber = project.ProjectName;
               proj.ProjectName = project.ProjectName;
               try
               {
                  proj.StatusDate = Db.ProjectStatus.Where(x => x.ProjectId == project.ProjectId).Max(x => x.StatusDate);
               }
               catch (NullReferenceException)
               {
                  proj.StatusDate = null;
               }
               catch (InvalidOperationException)
               {
                  proj.StatusDate = null;
               }
               proj.Status = flags.StatusColor(proj.StatusDate);
               returnlist.Add(proj);
            }

            return returnlist;

         }
         else
         {
            return null;
         }
         
      }
   }
}
