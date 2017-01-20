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
    // Address
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class Address
    {

        public int AddressKey { get; set; } // AddressKey (Primary key)

        public string Address1 { get; set; } // Address1

        public string Address2 { get; set; } // Address2

        public string City { get; set; } // City

        public int? StateKey { get; set; } // StateKey

        public string ZipCode { get; set; } // ZipCode

        // Reverse navigation
        public virtual ICollection<User> Users { get; set; } // Many to many mapping

        // Foreign keys
        public virtual State State { get; set; } // FK_Address_State
        
        public Address()
        {
            Users = new List<User>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
