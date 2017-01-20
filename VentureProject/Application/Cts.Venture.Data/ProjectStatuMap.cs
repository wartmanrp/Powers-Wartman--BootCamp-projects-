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
    // ProjectStatus
    internal partial class ProjectStatuMap : EntityTypeConfiguration<ProjectStatu>
    {
        public ProjectStatuMap()
            : this("dbo")
        {
        }
 
        public ProjectStatuMap(string schema)
        {
            ToTable(schema + ".ProjectStatus");
            HasKey(x => x.ProjectStatusId);

            Property(x => x.ProjectStatusId).HasColumnName("ProjectStatusID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ExecutiveSummary).HasColumnName("ExecutiveSummary").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(3000);
            Property(x => x.Accomplishments).HasColumnName("Accomplishments").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(3000);
            Property(x => x.PlannedActivities).HasColumnName("PlannedActivities").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(3000);
            Property(x => x.StatusDate).HasColumnName("StatusDate").IsRequired().HasColumnType("datetime");
            Property(x => x.ProjectId).HasColumnName("ProjectID").IsOptional().HasColumnType("int");
            Property(x => x.PercentEffort).HasColumnName("PercentEffort").IsRequired().HasColumnType("decimal").HasPrecision(10,2);

            // Foreign keys
            HasOptional(a => a.Project).WithMany(b => b.ProjectStatus).HasForeignKey(c => c.ProjectId); // Project_ProjectStatus_FK1
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
