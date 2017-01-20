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
    // ProjectHealth
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class ProjectHealth
    {

        public int ProjectHealthId { get; set; } // ProjectHealthID (Primary key)

        public string ProjectHealth_ { get; set; } // ProjectHealth

        // Reverse navigation
        public virtual ICollection<ProjectProjectHealth> ProjectProjectHealths { get; set; } // ProjectProjectHealth.ProjectHealth_ProjectProjectHealth_FK1
        
        public ProjectHealth()
        {
            ProjectProjectHealths = new List<ProjectProjectHealth>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
