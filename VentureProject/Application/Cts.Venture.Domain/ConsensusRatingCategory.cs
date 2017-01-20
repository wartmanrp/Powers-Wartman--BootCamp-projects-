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
    // ConsensusRatingCategory
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class ConsensusRatingCategory
    {

        public int ConsensusRatingCategoryId { get; set; } // ConsensusRatingCategoryID (Primary key)

        public string ConsensusRatingCategory_ { get; set; } // ConsensusRatingCategory

        // Reverse navigation
        public virtual ICollection<ProjectConsensusRating> ProjectConsensusRatings { get; set; } // ProjectConsensusRating.ConsensusRatingCategory_ProjectConsensusRating_FK1
        
        public ConsensusRatingCategory()
        {
            ProjectConsensusRatings = new List<ProjectConsensusRating>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
