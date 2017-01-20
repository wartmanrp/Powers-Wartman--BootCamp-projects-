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
    // Department
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public partial class Department
    {

        public int DepartmentId { get; set; } // DepartmentID (Primary key)

        public string Department_ { get; set; } // Department

        public int DepartmentHeadId { get; set; } // DepartmentHeadID

        public bool Deleted { get; set; } // Deleted

        // Reverse navigation
        public virtual ICollection<Issue> Issues { get; set; } // Issue.Department_Issue_FK1
        public virtual ICollection<Project> Projects { get; set; } // Project.Department_Project_FK1

        // Foreign keys
        public virtual Resource Resource { get; set; } // Resource_Department_FK1
        
        public Department()
        {
            Deleted = false;
            Issues = new List<Issue>();
            Projects = new List<Project>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
