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
    // IssueStatus
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class IssueStatu
    {

        public int IssueStatusId { get; set; } // IssueStatusID (Primary key)

        public string IssueStatus { get; set; } // IssueStatus

        // Reverse navigation
        public virtual ICollection<Issue> Issues { get; set; } // Issue.IssueStatus_Issue_FK1
        
        public IssueStatu()
        {
            Issues = new List<Issue>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
