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
    // User
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class User
    {

        public int UserKey { get; set; } // UserKey (Primary key)

        public string Username { get; set; } // Username

        public string Password { get; set; } // Password

        public string FirstName { get; set; } // FirstName

        public string MiddleName { get; set; } // MiddleName

        public string LastName { get; set; } // LastName

        public string Phone { get; set; } // Phone

        public DateTime? DateOfBirth { get; set; } // DateOfBirth

        public string Email { get; set; } // Email

        public int? SupervisorUserKey { get; set; } // SupervisorUserKey

        // Reverse navigation
        public virtual ICollection<Address> Addresses { get; set; } // Many to many mapping
        public virtual ICollection<Role> Roles { get; set; } // Many to many mapping
        public virtual ICollection<User> Users { get; set; } // User.FK_User_Supervisor

        // Foreign keys
        public virtual User User_SupervisorUserKey { get; set; } // FK_User_Supervisor
        
        public User()
        {
            Users = new List<User>();
            Addresses = new List<Address>();
            Roles = new List<Role>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
