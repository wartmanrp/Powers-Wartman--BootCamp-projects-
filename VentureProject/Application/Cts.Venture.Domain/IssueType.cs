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
    // IssueType
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class IssueType
    {

        public int IssueTypeId { get; set; } // IssueTypeID (Primary key)

        public string IssueType_ { get; set; } // IssueType

        // Reverse navigation
        public virtual ICollection<Issue> Issues { get; set; } // Issue.IssueType_Issue_FK1
        
        public IssueType()
        {
            Issues = new List<Issue>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
