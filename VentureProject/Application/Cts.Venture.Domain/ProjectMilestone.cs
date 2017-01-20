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
    // ProjectMilestone
    public partial class ProjectMilestone
    {

        public int ProjectMilestoneId { get; set; } // ProjectMilestoneID (Primary key)

        public int? ProjectId { get; set; } // ProjectID

        public DateTime? BaselineStart { get; set; } // BaselineStart

        public DateTime? BaselineFinish { get; set; } // BaselineFinish

        public DateTime? RevisedStart { get; set; } // RevisedStart

        public DateTime? RevisedFinish { get; set; } // RevisedFinish

        public DateTime? ActualStart { get; set; } // ActualStart

        public DateTime? ActualFinish { get; set; } // ActualFinish

        public decimal? PercentComplete { get; set; } // PercentComplete

        public string Milestone { get; set; } // Milestone

        public bool? ShowInReport { get; set; } // ShowInReport

        // Foreign keys
        public virtual Project Project { get; set; } // Project_ProjectMilestone_FK1
        
        public ProjectMilestone()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
