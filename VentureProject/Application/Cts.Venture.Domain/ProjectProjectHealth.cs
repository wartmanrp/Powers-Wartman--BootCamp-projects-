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
    // ProjectProjectHealth
    public partial class ProjectProjectHealth
    {

        public int ProjectProjectHealthId { get; set; } // ProjectProjectHealthID (Primary key)

        public int ProjectHealthId { get; set; } // ProjectHealthID

        public int ProjectId { get; set; } // ProjectID

        public DateTime ProjectHealthDate { get; set; } // ProjectHealthDate

        // Foreign keys
        public virtual Project Project { get; set; } // Project_ProjectProjectHealth_FK1
        public virtual ProjectHealth ProjectHealth { get; set; } // ProjectHealth_ProjectProjectHealth_FK1
        
        public ProjectProjectHealth()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
