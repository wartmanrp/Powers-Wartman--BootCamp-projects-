// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
// TargetFrameworkVersion = 4.6
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using System;
using Cts.Venture.Domain;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.ComponentModel.DataAnnotations;

namespace Cts.Venture.Domain
{
    // Project
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class Project
    {

        public int ProjectId { get; set; } // ProjectID (Primary key)

        public string ProjectName { get; set; } // ProjectName

        public int ProjectYear { get; set; } // ProjectYear

        public int ProjectSeqNumber { get; set; } // ProjectSeqNumber

        public bool? Watchlist { get; set; } // Watchlist

        public string BusinessIssue { get; set; } // BusinessIssue

        public string Solution { get; set; } // Solution

        public string Benefits { get; set; } // Benefits

        public string ProjectDirectory { get; set; } // ProjectDirectory

        public int? DepartmentId { get; set; } // DepartmentID

        public int? ProjectGoalId { get; set; } // ProjectGoalID

        public int? ProjectLevelId { get; set; } // ProjectLevelID

        public int? Lobid { get; set; } // LOBID

        public int? IndicatorId { get; set; } // IndicatorID

        public string ProjectNumber { get; set; } // ProjectNumber

        public string PriorityCode { get; set; } // PriorityCode

        // Reverse navigation
        public virtual ICollection<FinancialInformation> FinancialInformations { get; set; } // FinancialInformation.Project_FinancialInformation_FK1
        public virtual ICollection<LessonLearned> LessonLearneds { get; set; } // LessonLearned.Project_LessonLearned_FK1
        public virtual ICollection<ProjectConsensusRating> ProjectConsensusRatings { get; set; } // ProjectConsensusRating.Project_ProjectConsensusRating_FK1
        public virtual ICollection<ProjectMilestone> ProjectMilestones { get; set; } // ProjectMilestone.Project_ProjectMilestone_FK1
        public virtual ICollection<ProjectProjectHealth> ProjectProjectHealths { get; set; } // ProjectProjectHealth.Project_ProjectProjectHealth_FK1
        public virtual ICollection<ProjectRatingHistory> ProjectRatingHistories { get; set; } // ProjectRatingHistory.Project_ProjectRatingHistory_FK1
        public virtual ICollection<ProjectStandardMilestone> ProjectStandardMilestones { get; set; } // ProjectStandardMilestone.Project_ProjectStandardMilestone_FK1
        public virtual ICollection<ProjectStatu> ProjectStatus { get; set; } // ProjectStatus.Project_ProjectStatus_FK1
        public virtual ICollection<ProjectTeam> ProjectTeams { get; set; } // ProjectTeam.Project_ProjectTeam_FK1
        public virtual ICollection<Risk> Risks { get; set; } // Risk.Project_Risk_FK1

        // Foreign keys
        public virtual Department Department { get; set; } // Department_Project_FK1
        public virtual Indicator Indicator { get; set; } // Indicator_Project_FK1
        public virtual Lob Lob { get; set; } // LOB_Project_FK1
        public virtual ProjectGoal ProjectGoal { get; set; } // ProjectGoal_Project_FK1
        public virtual ProjectLevel ProjectLevel { get; set; } // ProjectLevel_Project_FK1
        
        public Project()
        {
            PriorityCode = "0000";
            FinancialInformations = new List<FinancialInformation>();
            LessonLearneds = new List<LessonLearned>();
            ProjectConsensusRatings = new List<ProjectConsensusRating>();
            ProjectMilestones = new List<ProjectMilestone>();
            ProjectProjectHealths = new List<ProjectProjectHealth>();
            ProjectRatingHistories = new List<ProjectRatingHistory>();
            ProjectStandardMilestones = new List<ProjectStandardMilestone>();
            ProjectStatus = new List<ProjectStatu>();
            ProjectTeams = new List<ProjectTeam>();
            Risks = new List<Risk>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
