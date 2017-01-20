using Cts.Venture.Common.Exceptions;
using Cts.Venture.Common.PaginateList;
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
   /// <summary>This class acts as the controller for all functions found on the view today view.</summary>
   /// <author>Powers Wartman</author>
   /// <date>October 17, 2016</date>
   /// <copyright> 
   /// Copyright (c) 2016 Computer Technology Solutions, Inc.  ALL      
   /// RIGHTS RESERVED
   /// </copyright>
   public class ViewTodayController : BaseController
    {
      //Hardcoded user key for all user based functions.
      private int UserKey = 5;

      /// <summary>This function returns the view today page for a specific user.</summary>
      /// <author>Powers Wartman</author>
      /// <date>October 17, 2016</date>
      /// <return>Returns a View containing the model desired.</return>
      /// <history>
      /// Date              Author         Change Reason  Change Description
      /// ----------------------------------------------------------------
      /// October 17, 2016  Powers Wartman   Created       Created method
      /// ----------------------------------------------------------------
      /// </history>
      [HttpGet]
      public ActionResult Index()
      {
         //start services
         UserService uService = new UserService(ServiceContext);
            
         ViewTodayDto model = new ViewTodayDto();
         model.User = uService.GetUser();            
         return View(model);
      }

      /// <summary>This function builds a paged list of for a users project tracking items.</summary>
      /// <author>Powers Wartman</author>
      /// <date>October 17, 2016</date>
      /// <return>Returns a partial view of project tracking items.</return>
      /// <param name="pageSortCriteria">An object containing criteria used to build the paged list.</param>
      /// <history>
      /// Date              Author         Change Reason  Change Description
      /// ----------------------------------------------------------------
      /// October 17, 2016  Powers Wartman   Created       Created method
      /// ----------------------------------------------------------------
      /// </history>
      public PartialViewResult GetProjectTrackingItemsPartial(PageSortCriteria pageSortCriteria)
      {
         pageSortCriteria.Page = pageSortCriteria.Page ?? 1;
         string filters = BuildFilter(pageSortCriteria.Filter);

         ProjectTrackingItemsService pService = new ProjectTrackingItemsService(ServiceContext);

         var model = pService.GetProjectTrackingItems(UserKey, pageSortCriteria.Page.Value, 1, pageSortCriteria.Sort, pageSortCriteria.Order, filters);

         return PartialView("_ProjectTrackingItemsPartial", model);
      }


      /// <summary>This function gets a list of project milestones for the user.</summary>
      /// <author>Powers Wartman</author>
      /// <date>October 17, 2016</date>
      /// <return>Returns a partial view of project milestones.</return>
      /// <param name="user">A user key/id.</param>
      /// <history>
      /// Date              Author         Change Reason  Change Description
      /// ----------------------------------------------------------------
      /// October 17, 2016  Powers Wartman   Created       Created method
      /// ----------------------------------------------------------------
      /// </history>
      [ChildActionOnly]
      public PartialViewResult GetProjectMilestonesPartial(int user)
      {
         MilestonesService mService = new MilestonesService(ServiceContext);

         ViewTodayDto model = new ViewTodayDto();
         model.UpcomingMilestones = mService.GetUpcomingMileStones(user);

         return PartialView("_ProjectMilestonesPartial", model);
      }

      /// <summary>This function handles search functionality.</summary>
      /// <author>Powers Wartman</author>
      /// <date>October 17, 2016</date>
      /// <return>Returns various partial views dependent on the results of the search.</return>
      /// <param name="input">A string input of the desired search terms.</param>
      /// <history>
      /// Date              Author         Change Reason  Change Description
      /// ----------------------------------------------------------------
      /// October 17, 2016  Powers Wartman   Created       Created method
      /// ----------------------------------------------------------------
      /// </history>
      [HttpPost]
      [AjaxOrChildAction]
      public ActionResult Search(SearchParamsDto input)
      {
         UserService uService = new UserService(ServiceContext);
         SearchService Search = new SearchService(ServiceContext);
         SearchResultsDto model = new SearchResultsDto();
         var user = uService.GetUser();
         input.ResourceId = user.ResourceId;
         try
         {
            model.SearchResults = Search.SearchByProjectNumber(input);
            if (string.IsNullOrEmpty(input.ProjectName) && string.IsNullOrEmpty(input.ProjectNumber))
            {
               return PartialView("_EnterTermsPartial");
            }
            else if (model.SearchResults.Count() == 0)
            {
               return PartialView("_NoResultsPartial");
            }
            else if(model.SearchResults.Count() > 0 || !model.SearchResults.Contains(null))
            {
               return PartialView("_SearchResultsPartial", model);
            }
            else if (model.SearchResults.Count() > 25)
            {
               return PartialView("_MaxResultsPartial");
            }
            else
            {
               return PartialView("_NoResultsPartial");
            }

         }
         catch (FrameworkException)
         {
            return PartialView("_NoResultsFound");
         }
      }

   }
}