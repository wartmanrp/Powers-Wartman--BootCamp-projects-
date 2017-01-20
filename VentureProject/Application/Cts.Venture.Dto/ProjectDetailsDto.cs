using Cts.Venture.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cts.Venture.Dto
{
   /// <summary>This class represents all of the data related to a project entity, as well as the dropdown lists used when building the maintain project details partial.</summary>
   /// <author>Powers Wartman</author>
   /// <date>September 21, 2016</date>
   /// <copyright> 
   /// Copyright (c) 2016 Computer Technology Solutions, Inc.  ALL      
   /// RIGHTS RESERVED
   /// </copyright>
   public class ProjectDetailsDto
   {
      public int ProjectId { get; set; }
      public string ProjectNumber { get; set; }

      [Required(AllowEmptyStrings = false, ErrorMessage ="A name is required.")]
      [StringLength(50, MinimumLength= 1)]
      public string ProjectName { get; set; }
      public string ProjectStatus { get; set; }
      public int ProjectSeqNumber { get; set; }
      public decimal? ProjectCompletion { get; set; }

      public bool AddToWatchList { get; set; }

      [Required]
      public int? ProjectGoalId { get; set; }

      [Required]
      public int? ProjectLevelId { get; set; }

      [Required]
      public int? ProjectIndicatorId { get; set; }

      [Required]
      public int? LobId { get; set; }

      [Required]
      public int? DepartmentId { get; set; }

      [StringLength(3000)]
      public string BusinessIssue { get; set; }

      [StringLength(3000)]
      public string Solution { get; set; }

      [StringLength(3000)]
      public string Benefits { get; set; }

      [Required(AllowEmptyStrings = false, ErrorMessage = "A directory is required.")]
      [StringLength(255, MinimumLength = 1, ErrorMessage = "Directory address must be less than 255 characters")]
      public string ProjectDirectory { get; set; }

      //lists for selecting stuff
      public List<ProjectGoalDto> ProjectGoalsList { get; set; }
      public List<ProjectLevelDto> ProjectLevelsList { get; set; }
      public List<IndicatorDto> IndicatorsList { get; set; }
      public List<LobDto> LobsList { get; set; }
      public List<DepartmentDto> DepartmentsList { get; set; }
      
   }
}
