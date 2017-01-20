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
    // ProjectConsensusRating
    public partial class ProjectConsensusRating
    {

        public int ProjectConsensusRatingId { get; set; } // ProjectConsensusRatingID (Primary key)

        public int RatingCategoryId { get; set; } // RatingCategoryID

        public int ProjectId { get; set; } // ProjectID

        public bool VeryDissatisfied { get; set; } // VeryDissatisfied

        public bool Dissatisfied { get; set; } // Dissatisfied

        public bool Neutral { get; set; } // Neutral

        public bool Satisfied { get; set; } // Satisfied

        public bool VerySatisfied { get; set; } // VerySatisfied

        // Foreign keys
        public virtual ConsensusRatingCategory ConsensusRatingCategory { get; set; } // ConsensusRatingCategory_ProjectConsensusRating_FK1
        public virtual Project Project { get; set; } // Project_ProjectConsensusRating_FK1
        
        public ProjectConsensusRating()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
