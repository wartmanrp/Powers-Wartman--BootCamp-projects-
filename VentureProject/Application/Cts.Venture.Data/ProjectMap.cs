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
    // Project
    internal partial class ProjectMap : EntityTypeConfiguration<Project>
    {
        public ProjectMap()
            : this("dbo")
        {
        }
 
        public ProjectMap(string schema)
        {
            ToTable(schema + ".Project");
            HasKey(x => x.ProjectId);

            Property(x => x.ProjectId).HasColumnName("ProjectID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProjectName).HasColumnName("ProjectName").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.ProjectYear).HasColumnName("ProjectYear").IsRequired().HasColumnType("int");
            Property(x => x.ProjectSeqNumber).HasColumnName("ProjectSeqNumber").IsRequired().HasColumnType("int");
            Property(x => x.Watchlist).HasColumnName("Watchlist").IsOptional().HasColumnType("bit");
            Property(x => x.BusinessIssue).HasColumnName("BusinessIssue").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(3000);
            Property(x => x.Solution).HasColumnName("Solution").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(3000);
            Property(x => x.Benefits).HasColumnName("Benefits").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(3000);
            Property(x => x.ProjectDirectory).HasColumnName("ProjectDirectory").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(2000);
            Property(x => x.DepartmentId).HasColumnName("DepartmentID").IsOptional().HasColumnType("int");
            Property(x => x.ProjectGoalId).HasColumnName("ProjectGoalID").IsOptional().HasColumnType("int");
            Property(x => x.ProjectLevelId).HasColumnName("ProjectLevelID").IsOptional().HasColumnType("int");
            Property(x => x.Lobid).HasColumnName("LOBID").IsOptional().HasColumnType("int");
            Property(x => x.IndicatorId).HasColumnName("IndicatorID").IsOptional().HasColumnType("int");
            Property(x => x.ProjectNumber).HasColumnName("ProjectNumber").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(20);
            Property(x => x.PriorityCode).HasColumnName("PriorityCode").IsRequired().IsFixedLength().IsUnicode(false).HasColumnType("char").HasMaxLength(4);

            // Foreign keys
            HasOptional(a => a.Department).WithMany(b => b.Projects).HasForeignKey(c => c.DepartmentId); // Department_Project_FK1
            HasOptional(a => a.Indicator).WithMany(b => b.Projects).HasForeignKey(c => c.IndicatorId); // Indicator_Project_FK1
            HasOptional(a => a.Lob).WithMany(b => b.Projects).HasForeignKey(c => c.Lobid); // LOB_Project_FK1
            HasOptional(a => a.ProjectGoal).WithMany(b => b.Projects).HasForeignKey(c => c.ProjectGoalId); // ProjectGoal_Project_FK1
            HasOptional(a => a.ProjectLevel).WithMany(b => b.Projects).HasForeignKey(c => c.ProjectLevelId); // ProjectLevel_Project_FK1
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
