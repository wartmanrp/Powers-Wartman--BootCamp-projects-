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
    // ProjectStatus
    public partial class ProjectStatu
    {

        public int ProjectStatusId { get; set; } // ProjectStatusID (Primary key)

        public string ExecutiveSummary { get; set; } // ExecutiveSummary

        public string Accomplishments { get; set; } // Accomplishments

        public string PlannedActivities { get; set; } // PlannedActivities

        public DateTime StatusDate { get; set; } // StatusDate

        public int? ProjectId { get; set; } // ProjectID

        public decimal PercentEffort { get; set; } // PercentEffort

        // Foreign keys
        public virtual Project Project { get; set; } // Project_ProjectStatus_FK1
        
        public ProjectStatu()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
