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
    // Issue
    public partial class Issue
    {

        public int IssueId { get; set; } // IssueID (Primary key)

        public int IssueTypeId { get; set; } // IssueTypeID

        public int IssueStatusId { get; set; } // IssueStatusID

        public int DepartmentId { get; set; } // DepartmentID

        public int ProjectTeamId { get; set; } // ProjectTeamID

        public DateTime? TargetDate { get; set; } // TargetDate

        public DateTime? ActualDate { get; set; } // ActualDate

        public string Issue_ { get; set; } // Issue

        public string NextAction { get; set; } // NextAction

        public string Source { get; set; } // Source

        public int? IssueNumber { get; set; } // IssueNumber

        // Foreign keys
        public virtual Department Department { get; set; } // Department_Issue_FK1
        public virtual IssueStatu IssueStatu { get; set; } // IssueStatus_Issue_FK1
        public virtual IssueType IssueType { get; set; } // IssueType_Issue_FK1
        public virtual ProjectTeam ProjectTeam { get; set; } // ProjectTeam_Issue_FK1
        
        public Issue()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
