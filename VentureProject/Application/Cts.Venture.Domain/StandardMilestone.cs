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
    // StandardMilestone
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class StandardMilestone
    {

        public int StandardMilestoneId { get; set; } // StandardMilestoneID (Primary key)

        public string StandardMilestone_ { get; set; } // StandardMilestone

        public int? BaselinePoints { get; set; } // BaselinePoints

        // Reverse navigation
        public virtual ICollection<ProjectStandardMilestone> ProjectStandardMilestones { get; set; } // ProjectStandardMilestone.StandardMilestone_ProjectStandardMilestone_FK1
        
        public StandardMilestone()
        {
            ProjectStandardMilestones = new List<ProjectStandardMilestone>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
