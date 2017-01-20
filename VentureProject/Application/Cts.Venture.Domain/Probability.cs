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
    // Probability
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class Probability
    {

        public int ProbabilityId { get; set; } // ProbabilityID (Primary key)

        public string Probability_ { get; set; } // Probability

        // Reverse navigation
        public virtual ICollection<Risk> Risks { get; set; } // Risk.Probability_Risk_FK1
        
        public Probability()
        {
            Risks = new List<Risk>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
