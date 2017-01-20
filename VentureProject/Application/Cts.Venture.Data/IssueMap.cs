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
    // Issue
    internal partial class IssueMap : EntityTypeConfiguration<Issue>
    {
        public IssueMap()
            : this("dbo")
        {
        }
 
        public IssueMap(string schema)
        {
            ToTable(schema + ".Issue");
            HasKey(x => x.IssueId);

            Property(x => x.IssueId).HasColumnName("IssueID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.IssueTypeId).HasColumnName("IssueTypeID").IsRequired().HasColumnType("int");
            Property(x => x.IssueStatusId).HasColumnName("IssueStatusID").IsRequired().HasColumnType("int");
            Property(x => x.DepartmentId).HasColumnName("DepartmentID").IsRequired().HasColumnType("int");
            Property(x => x.ProjectTeamId).HasColumnName("ProjectTeamID").IsRequired().HasColumnType("int");
            Property(x => x.TargetDate).HasColumnName("TargetDate").IsOptional().HasColumnType("datetime");
            Property(x => x.ActualDate).HasColumnName("ActualDate").IsOptional().HasColumnType("datetime");
            Property(x => x.Issue_).HasColumnName("Issue").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.NextAction).HasColumnName("NextAction").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.Source).HasColumnName("Source").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(25);
            Property(x => x.IssueNumber).HasColumnName("IssueNumber").IsOptional().HasColumnType("int");

            // Foreign keys
            HasRequired(a => a.Department).WithMany(b => b.Issues).HasForeignKey(c => c.DepartmentId); // Department_Issue_FK1
            HasRequired(a => a.IssueStatu).WithMany(b => b.Issues).HasForeignKey(c => c.IssueStatusId); // IssueStatus_Issue_FK1
            HasRequired(a => a.IssueType).WithMany(b => b.Issues).HasForeignKey(c => c.IssueTypeId); // IssueType_Issue_FK1
            HasRequired(a => a.ProjectTeam).WithMany(b => b.Issues).HasForeignKey(c => c.ProjectTeamId); // ProjectTeam_Issue_FK1
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
