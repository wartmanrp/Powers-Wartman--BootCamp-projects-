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
    // ProjectRating
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class ProjectRating
    {

        public int ProjectRatingId { get; set; } // ProjectRatingID (Primary key)

        public string ProjectRating_ { get; set; } // ProjectRating

        // Reverse navigation
        public virtual ICollection<ProjectRatingHistory> ProjectRatingHistories { get; set; } // ProjectRatingHistory.ProjectRating_ProjectRatingHistory_FK1
        
        public ProjectRating()
        {
            ProjectRatingHistories = new List<ProjectRatingHistory>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
