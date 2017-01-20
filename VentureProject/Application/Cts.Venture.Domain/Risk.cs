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
    // Risk
    public partial class Risk
    {

        public int RiskId { get; set; } // RiskID (Primary key)

        public int ProjectTeamId { get; set; } // ProjectTeamID

        public DateTime TargetDate { get; set; } // TargetDate

        public string Risk_ { get; set; } // Risk

        public string MitigationApproach { get; set; } // MitigationApproach

        public int ImpactId { get; set; } // ImpactID

        public int ProbabilityId { get; set; } // ProbabilityID

        public int RiskStatusId { get; set; } // RiskStatusID

        public string Notes { get; set; } // Notes

        public bool ShowInStatus { get; set; } // ShowInStatus

        public int? ProjectId { get; set; } // ProjectID

        public int RiskNumber { get; set; } // RiskNumber

        // Foreign keys
        public virtual Impact Impact { get; set; } // Impact_Risk_FK1
        public virtual Probability Probability { get; set; } // Probability_Risk_FK1
        public virtual Project Project { get; set; } // Project_Risk_FK1
        public virtual ProjectTeam ProjectTeam { get; set; } // ProjectTeam_Risk_FK1
        public virtual RiskStatu RiskStatu { get; set; } // RiskStatus_Risk_FK1
        
        public Risk()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
