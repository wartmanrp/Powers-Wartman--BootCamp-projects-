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
    // ProjectTeam
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class ProjectTeam
    {

        public int ProjectTeamId { get; set; } // ProjectTeamID (Primary key)

        public int ResourceId { get; set; } // ResourceID

        public bool Deleted { get; set; } // Deleted

        public int? ProjectId { get; set; } // ProjectID

        // Reverse navigation
        public virtual ICollection<Issue> Issues { get; set; } // Issue.ProjectTeam_Issue_FK1
        public virtual ICollection<ProjectTeamRole> ProjectTeamRoles { get; set; } // ProjectTeamRole.ProjectTeam_ProjectTeamRole_FK1
        public virtual ICollection<Risk> Risks { get; set; } // Risk.ProjectTeam_Risk_FK1

        // Foreign keys
        public virtual Project Project { get; set; } // Project_ProjectTeam_FK1
        public virtual Resource Resource { get; set; } // Resource_ProjectTeam_FK1
        
        public ProjectTeam()
        {
            Deleted = false;
            Issues = new List<Issue>();
            ProjectTeamRoles = new List<ProjectTeamRole>();
            Risks = new List<Risk>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
