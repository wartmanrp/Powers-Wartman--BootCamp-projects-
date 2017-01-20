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
    // ProjectTeam
    internal partial class ProjectTeamMap : EntityTypeConfiguration<ProjectTeam>
    {
        public ProjectTeamMap()
            : this("dbo")
        {
        }
 
        public ProjectTeamMap(string schema)
        {
            ToTable(schema + ".ProjectTeam");
            HasKey(x => x.ProjectTeamId);

            Property(x => x.ProjectTeamId).HasColumnName("ProjectTeamID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ResourceId).HasColumnName("ResourceID").IsRequired().HasColumnType("int");
            Property(x => x.Deleted).HasColumnName("Deleted").IsRequired().HasColumnType("bit");
            Property(x => x.ProjectId).HasColumnName("ProjectID").IsOptional().HasColumnType("int");

            // Foreign keys
            HasOptional(a => a.Project).WithMany(b => b.ProjectTeams).HasForeignKey(c => c.ProjectId); // Project_ProjectTeam_FK1
            HasRequired(a => a.Resource).WithMany(b => b.ProjectTeams).HasForeignKey(c => c.ResourceId); // Resource_ProjectTeam_FK1
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
