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
    // ProjectTeamRole
    internal partial class ProjectTeamRoleMap : EntityTypeConfiguration<ProjectTeamRole>
    {
        public ProjectTeamRoleMap()
            : this("dbo")
        {
        }
 
        public ProjectTeamRoleMap(string schema)
        {
            ToTable(schema + ".ProjectTeamRole");
            HasKey(x => x.ProjectTeamRoleId);

            Property(x => x.ProjectTeamRoleId).HasColumnName("ProjectTeamRoleID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TeamRoleId).HasColumnName("TeamRoleID").IsOptional().HasColumnType("int");
            Property(x => x.ProjectTeamId).HasColumnName("ProjectTeamID").IsOptional().HasColumnType("int");

            // Foreign keys
            HasOptional(a => a.ProjectTeam).WithMany(b => b.ProjectTeamRoles).HasForeignKey(c => c.ProjectTeamId); // ProjectTeam_ProjectTeamRole_FK1
            HasOptional(a => a.TeamRole).WithMany(b => b.ProjectTeamRoles).HasForeignKey(c => c.TeamRoleId); // TeamRole_ProjectTeamRole_FK1
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
