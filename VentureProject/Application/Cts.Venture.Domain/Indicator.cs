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
    // Indicator
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class Indicator
    {

        public int IndicatorId { get; set; } // IndicatorID (Primary key)

        public string ProjectIndicator { get; set; } // ProjectIndicator

        public int SortNumber { get; set; } // SortNumber

        public int? ProjectStatusId { get; set; } // ProjectStatusID

        public bool Deleted { get; set; } // Deleted

        // Reverse navigation
        public virtual ICollection<Project> Projects { get; set; } // Project.Indicator_Project_FK1

        // Foreign keys
        public virtual Status Status { get; set; } // Status_Indicator_FK1
        
        public Indicator()
        {
            Deleted = false;
            Projects = new List<Project>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
