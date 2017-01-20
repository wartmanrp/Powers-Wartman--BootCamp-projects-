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
    // Status
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class Status
    {

        public int StatusId { get; set; } // StatusID (Primary key)

        public string Status_ { get; set; } // Status

        // Reverse navigation
        public virtual ICollection<Indicator> Indicators { get; set; } // Indicator.Status_Indicator_FK1
        
        public Status()
        {
            Indicators = new List<Indicator>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
