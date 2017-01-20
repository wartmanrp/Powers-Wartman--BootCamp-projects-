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
    // State
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class State
    {

        public int StateKey { get; set; } // StateKey (Primary key)

        public string StateName { get; set; } // StateName

        public string StateAbbrv { get; set; } // StateAbbrv

        // Reverse navigation
        public virtual ICollection<Address> Addresses { get; set; } // Address.FK_Address_State
        
        public State()
        {
            Addresses = new List<Address>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
