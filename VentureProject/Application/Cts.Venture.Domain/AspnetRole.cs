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
    // aspnet_Roles
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class AspnetRole
    {

        public Guid ApplicationId { get; set; } // ApplicationId

        public Guid RoleId { get; set; } // RoleId (Primary key)

        public string RoleName { get; set; } // RoleName

        public string LoweredRoleName { get; set; } // LoweredRoleName

        public string Description { get; set; } // Description

        // Reverse navigation
        public virtual ICollection<AspnetUser> AspnetUsers { get; set; } // Many to many mapping

        // Foreign keys
        public virtual AspnetApplication AspnetApplication { get; set; } // FK__aspnet_Ro__Appli__0A9D95DB
        
        public AspnetRole()
        {
            RoleId = System.Guid.NewGuid();
            AspnetUsers = new List<AspnetUser>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
