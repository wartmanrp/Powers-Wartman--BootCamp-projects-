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
    // TeamRole
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class TeamRole
    {

        public int TeamRoleId { get; set; } // TeamRoleID (Primary key)

        public string TeamRole_ { get; set; } // TeamRole

        // Reverse navigation
        public virtual ICollection<ProjectTeamRole> ProjectTeamRoles { get; set; } // ProjectTeamRole.TeamRole_ProjectTeamRole_FK1
        
        public TeamRole()
        {
            ProjectTeamRoles = new List<ProjectTeamRole>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
