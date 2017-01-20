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
    // LessonLearned
    public partial class LessonLearned
    {

        public int LessonLearnedId { get; set; } // LessonLearnedID (Primary key)

        public string Description { get; set; } // Description

        public string Recommendation { get; set; } // Recommendation

        public int? LessonLearnedTypeId { get; set; } // LessonLearnedTypeID

        public int? ProjectId { get; set; } // ProjectID

        // Foreign keys
        public virtual LessonLearnedType LessonLearnedType { get; set; } // LessonLearnedType_LessonLearned_FK1
        public virtual Project Project { get; set; } // Project_LessonLearned_FK1
        
        public LessonLearned()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
