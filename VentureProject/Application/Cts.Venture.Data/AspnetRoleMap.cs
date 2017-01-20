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
    // aspnet_Roles
    internal partial class AspnetRoleMap : EntityTypeConfiguration<AspnetRole>
    {
        public AspnetRoleMap()
            : this("dbo")
        {
        }
 
        public AspnetRoleMap(string schema)
        {
            ToTable(schema + ".aspnet_Roles");
            HasKey(x => x.RoleId);

            Property(x => x.ApplicationId).HasColumnName("ApplicationId").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.RoleId).HasColumnName("RoleId").IsRequired().HasColumnType("uniqueidentifier").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.RoleName).HasColumnName("RoleName").IsRequired().HasColumnType("nvarchar").HasMaxLength(256);
            Property(x => x.LoweredRoleName).HasColumnName("LoweredRoleName").IsRequired().HasColumnType("nvarchar").HasMaxLength(256);
            Property(x => x.Description).HasColumnName("Description").IsOptional().HasColumnType("nvarchar").HasMaxLength(256);

            // Foreign keys
            HasRequired(a => a.AspnetApplication).WithMany(b => b.AspnetRoles).HasForeignKey(c => c.ApplicationId); // FK__aspnet_Ro__Appli__0A9D95DB
            HasMany(t => t.AspnetUsers).WithMany(t => t.AspnetRoles).Map(m => 
            {
                m.ToTable("aspnet_UsersInRoles", "dbo");
                m.MapLeftKey("RoleId");
                m.MapRightKey("UserId");
            });
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
