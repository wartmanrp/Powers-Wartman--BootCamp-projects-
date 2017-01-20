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
    // Risk
    internal partial class RiskMap : EntityTypeConfiguration<Risk>
    {
        public RiskMap()
            : this("dbo")
        {
        }
 
        public RiskMap(string schema)
        {
            ToTable(schema + ".Risk");
            HasKey(x => x.RiskId);

            Property(x => x.RiskId).HasColumnName("RiskID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProjectTeamId).HasColumnName("ProjectTeamID").IsRequired().HasColumnType("int");
            Property(x => x.TargetDate).HasColumnName("TargetDate").IsRequired().HasColumnType("datetime");
            Property(x => x.Risk_).HasColumnName("Risk").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.MitigationApproach).HasColumnName("MitigationApproach").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ImpactId).HasColumnName("ImpactID").IsRequired().HasColumnType("int");
            Property(x => x.ProbabilityId).HasColumnName("ProbabilityID").IsRequired().HasColumnType("int");
            Property(x => x.RiskStatusId).HasColumnName("RiskStatusID").IsRequired().HasColumnType("int");
            Property(x => x.Notes).HasColumnName("Notes").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(3000);
            Property(x => x.ShowInStatus).HasColumnName("ShowInStatus").IsRequired().HasColumnType("bit");
            Property(x => x.ProjectId).HasColumnName("ProjectID").IsOptional().HasColumnType("int");
            Property(x => x.RiskNumber).HasColumnName("RiskNumber").IsRequired().HasColumnType("int");

            // Foreign keys
            HasOptional(a => a.Project).WithMany(b => b.Risks).HasForeignKey(c => c.ProjectId); // Project_Risk_FK1
            HasRequired(a => a.Impact).WithMany(b => b.Risks).HasForeignKey(c => c.ImpactId); // Impact_Risk_FK1
            HasRequired(a => a.Probability).WithMany(b => b.Risks).HasForeignKey(c => c.ProbabilityId); // Probability_Risk_FK1
            HasRequired(a => a.ProjectTeam).WithMany(b => b.Risks).HasForeignKey(c => c.ProjectTeamId); // ProjectTeam_Risk_FK1
            HasRequired(a => a.RiskStatu).WithMany(b => b.Risks).HasForeignKey(c => c.RiskStatusId); // RiskStatus_Risk_FK1
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
