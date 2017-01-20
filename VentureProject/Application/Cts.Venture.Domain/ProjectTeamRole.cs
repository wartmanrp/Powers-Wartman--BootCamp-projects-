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
    // ProjectTeamRole
    public partial class ProjectTeamRole
    {

        public int ProjectTeamRoleId { get; set; } // ProjectTeamRoleID (Primary key)

        public int? TeamRoleId { get; set; } // TeamRoleID

        public int? ProjectTeamId { get; set; } // ProjectTeamID

        // Foreign keys
        public virtual ProjectTeam ProjectTeam { get; set; } // ProjectTeam_ProjectTeamRole_FK1
        public virtual TeamRole TeamRole { get; set; } // TeamRole_ProjectTeamRole_FK1
        
        public ProjectTeamRole()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
