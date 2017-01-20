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
    // aspnet_Applications
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class AspnetApplication
    {

        public string ApplicationName { get; set; } // ApplicationName

        public string LoweredApplicationName { get; set; } // LoweredApplicationName

        public Guid ApplicationId { get; set; } // ApplicationId (Primary key)

        public string Description { get; set; } // Description

        // Reverse navigation
        public virtual ICollection<AspnetRole> AspnetRoles { get; set; } // aspnet_Roles.FK__aspnet_Ro__Appli__0A9D95DB
        public virtual ICollection<AspnetUser> AspnetUsers { get; set; } // aspnet_Users.FK__aspnet_Us__Appli__76969D2E
        
        public AspnetApplication()
        {
            ApplicationId = System.Guid.NewGuid();
            AspnetRoles = new List<AspnetRole>();
            AspnetUsers = new List<AspnetUser>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
