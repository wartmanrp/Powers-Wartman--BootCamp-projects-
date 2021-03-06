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
    // LessonLearnedType
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class LessonLearnedType
    {

        public int LessonLearnedTypeId { get; set; } // LessonLearnedTypeID (Primary key)

        public string LessonLearnedType_ { get; set; } // LessonLearnedType

        public bool Deleted { get; set; } // Deleted

        // Reverse navigation
        public virtual ICollection<LessonLearned> LessonLearneds { get; set; } // LessonLearned.LessonLearnedType_LessonLearned_FK1
        
        public LessonLearnedType()
        {
            Deleted = false;
            LessonLearneds = new List<LessonLearned>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
