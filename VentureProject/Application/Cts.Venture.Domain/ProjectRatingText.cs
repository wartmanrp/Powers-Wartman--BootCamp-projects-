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
    // ProjectRatingText
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class ProjectRatingText
    {

        public int ProjectRatingTextId { get; set; } // ProjectRatingTextID (Primary key)

        public string ProjectRatingCode { get; set; } // ProjectRatingCode

        public string ProjectRatingText_ { get; set; } // ProjectRatingText

        // Reverse navigation
        public virtual ICollection<ProjectRatingHistory> ProjectRatingHistories { get; set; } // ProjectRatingHistory.ProjectRatingText_ProjectRatingHistory_FK1
        
        public ProjectRatingText()
        {
            ProjectRatingHistories = new List<ProjectRatingHistory>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
