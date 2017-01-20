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
    // Resource
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class Resource
    {

        public int ResourceId { get; set; } // ResourceID (Primary key)

        public string Resource_ { get; set; } // Resource

        public string Email { get; set; } // Email

        public string Phone { get; set; } // Phone

        public string UserId { get; set; } // UserID

        public bool Deleted { get; set; } // Deleted

        // Reverse navigation
        public virtual ICollection<Department> Departments { get; set; } // Department.Resource_Department_FK1
        public virtual ICollection<ProjectTeam> ProjectTeams { get; set; } // ProjectTeam.Resource_ProjectTeam_FK1
        
        public Resource()
        {
            Deleted = false;
            Departments = new List<Department>();
            ProjectTeams = new List<ProjectTeam>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
