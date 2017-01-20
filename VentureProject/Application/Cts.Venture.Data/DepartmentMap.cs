// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
// TargetFrameworkVersion = 4.6
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using System;
using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices; //HACK: VS not coping EntityFramework.SqlServer.dll;
using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Cts.Venture.Domain;
using System.Threading;
using System.ComponentModel.DataAnnotations;
//using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.DatabaseGeneratedOption;

namespace Cts.Venture.Data
{
    // Department
    internal partial class DepartmentMap : EntityTypeConfiguration<Department>
    {
        public DepartmentMap()
            : this("dbo")
        {
        }
 
        public DepartmentMap(string schema)
        {
            ToTable(schema + ".Department");
            HasKey(x => x.DepartmentId);

            Property(x => x.DepartmentId).HasColumnName("DepartmentID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Department_).HasColumnName("Department").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.DepartmentHeadId).HasColumnName("DepartmentHeadID").IsRequired().HasColumnType("int");
            Property(x => x.Deleted).HasColumnName("Deleted").IsRequired().HasColumnType("bit");

            // Foreign keys
            HasRequired(a => a.Resource).WithMany(b => b.Departments).HasForeignKey(c => c.DepartmentHeadId); // Resource_Department_FK1
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
