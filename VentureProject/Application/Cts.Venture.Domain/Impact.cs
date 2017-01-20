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
    // Impact
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class Impact
    {

        public int ImpactId { get; set; } // ImpactID (Primary key)

        public string Impact_ { get; set; } // Impact

        // Reverse navigation
        public virtual ICollection<Risk> Risks { get; set; } // Risk.Impact_Risk_FK1
        
        public Impact()
        {
            Risks = new List<Risk>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
