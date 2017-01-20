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
    // ProjectRatingHistory
    public partial class ProjectRatingHistory
    {

        public int ProjectRatingHistoryId { get; set; } // ProjectRatingHistoryID (Primary key)

        public int? ProjectRatingTextId { get; set; } // ProjectRatingTextId

        public int? ProjectId { get; set; } // ProjectID

        public int? ProjectRatingId { get; set; } // ProjectRatingID

        public DateTime? ProjectRatingDate { get; set; } // ProjectRatingDate

        // Foreign keys
        public virtual Project Project { get; set; } // Project_ProjectRatingHistory_FK1
        public virtual ProjectRating ProjectRating { get; set; } // ProjectRating_ProjectRatingHistory_FK1
        public virtual ProjectRatingText ProjectRatingText { get; set; } // ProjectRatingText_ProjectRatingHistory_FK1
        
        public ProjectRatingHistory()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
