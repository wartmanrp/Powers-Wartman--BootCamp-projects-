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
    // LOB
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class Lob
    {

        public int Lobid { get; set; } // LOBID (Primary key)

        public string Lob_ { get; set; } // LOB

        public bool Deleted { get; set; } // Deleted

        // Reverse navigation
        public virtual ICollection<Project> Projects { get; set; } // Project.LOB_Project_FK1
        
        public Lob()
        {
            Deleted = false;
            Projects = new List<Project>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
