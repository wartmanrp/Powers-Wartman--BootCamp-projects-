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
    // ProjectLevel
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class ProjectLevel
    {

        public int ProjectLevelId { get; set; } // ProjectLevelID (Primary key)

        public string ProjectLevel_ { get; set; } // ProjectLevel

        // Reverse navigation
        public virtual ICollection<Project> Projects { get; set; } // Project.ProjectLevel_Project_FK1
        
        public ProjectLevel()
        {
            Projects = new List<Project>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
