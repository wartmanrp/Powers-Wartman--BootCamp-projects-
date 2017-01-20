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
    // ProjectProjectHealth
    internal partial class ProjectProjectHealthMap : EntityTypeConfiguration<ProjectProjectHealth>
    {
        public ProjectProjectHealthMap()
            : this("dbo")
        {
        }
 
        public ProjectProjectHealthMap(string schema)
        {
            ToTable(schema + ".ProjectProjectHealth");
            HasKey(x => x.ProjectProjectHealthId);

            Property(x => x.ProjectProjectHealthId).HasColumnName("ProjectProjectHealthID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProjectHealthId).HasColumnName("ProjectHealthID").IsRequired().HasColumnType("int");
            Property(x => x.ProjectId).HasColumnName("ProjectID").IsRequired().HasColumnType("int");
            Property(x => x.ProjectHealthDate).HasColumnName("ProjectHealthDate").IsRequired().HasColumnType("datetime");

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.ProjectProjectHealths).HasForeignKey(c => c.ProjectId); // Project_ProjectProjectHealth_FK1
            HasRequired(a => a.ProjectHealth).WithMany(b => b.ProjectProjectHealths).HasForeignKey(c => c.ProjectHealthId); // ProjectHealth_ProjectProjectHealth_FK1
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
