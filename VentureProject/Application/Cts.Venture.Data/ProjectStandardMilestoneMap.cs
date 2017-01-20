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
    // ProjectStandardMilestone
    internal partial class ProjectStandardMilestoneMap : EntityTypeConfiguration<ProjectStandardMilestone>
    {
        public ProjectStandardMilestoneMap()
            : this("dbo")
        {
        }
 
        public ProjectStandardMilestoneMap(string schema)
        {
            ToTable(schema + ".ProjectStandardMilestone");
            HasKey(x => x.ProjectStandardMilestoneId);

            Property(x => x.ProjectStandardMilestoneId).HasColumnName("ProjectStandardMilestoneID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProjectId).HasColumnName("ProjectID").IsOptional().HasColumnType("int");
            Property(x => x.BaselineStart).HasColumnName("BaselineStart").IsOptional().HasColumnType("datetime");
            Property(x => x.BaselineFinish).HasColumnName("BaselineFinish").IsOptional().HasColumnType("datetime");
            Property(x => x.RevisedStart).HasColumnName("RevisedStart").IsOptional().HasColumnType("datetime");
            Property(x => x.RevisedFinish).HasColumnName("RevisedFinish").IsOptional().HasColumnType("datetime");
            Property(x => x.ActualStart).HasColumnName("ActualStart").IsOptional().HasColumnType("datetime");
            Property(x => x.ActualFinish).HasColumnName("ActualFinish").IsOptional().HasColumnType("datetime");
            Property(x => x.PercentComplete).HasColumnName("PercentComplete").IsOptional().HasColumnType("decimal").HasPrecision(10,2);
            Property(x => x.StandardMilestoneId).HasColumnName("StandardMilestoneID").IsOptional().HasColumnType("int");
            Property(x => x.ShowInReport).HasColumnName("ShowInReport").IsOptional().HasColumnType("bit");

            // Foreign keys
            HasOptional(a => a.Project).WithMany(b => b.ProjectStandardMilestones).HasForeignKey(c => c.ProjectId); // Project_ProjectStandardMilestone_FK1
            HasOptional(a => a.StandardMilestone).WithMany(b => b.ProjectStandardMilestones).HasForeignKey(c => c.StandardMilestoneId); // StandardMilestone_ProjectStandardMilestone_FK1
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
