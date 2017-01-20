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
    // aspnet_Users
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class AspnetUser
    {

        public Guid ApplicationId { get; set; } // ApplicationId

        public Guid UserId { get; set; } // UserId (Primary key)

        public string UserName { get; set; } // UserName

        public string LoweredUserName { get; set; } // LoweredUserName

        public string MobileAlias { get; set; } // MobileAlias

        public bool IsAnonymous { get; set; } // IsAnonymous

        public DateTime LastActivityDate { get; set; } // LastActivityDate

        // Reverse navigation
        public virtual ICollection<AspnetRole> AspnetRoles { get; set; } // Many to many mapping

        // Foreign keys
        public virtual AspnetApplication AspnetApplication { get; set; } // FK__aspnet_Us__Appli__76969D2E
        
        public AspnetUser()
        {
            UserId = System.Guid.NewGuid();
            MobileAlias = "NULL";
            IsAnonymous = false;
            AspnetRoles = new List<AspnetRole>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
