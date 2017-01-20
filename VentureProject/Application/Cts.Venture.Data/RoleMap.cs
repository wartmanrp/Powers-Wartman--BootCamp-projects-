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
    // Role
    internal partial class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
            : this("dbo")
        {
        }
 
        public RoleMap(string schema)
        {
            ToTable(schema + ".Role");
            HasKey(x => x.RoleKey);

            Property(x => x.RoleKey).HasColumnName("RoleKey").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.RoleName).HasColumnName("RoleName").IsRequired().HasColumnType("nvarchar").HasMaxLength(15);
            HasMany(t => t.Users).WithMany(t => t.Roles).Map(m => 
            {
                m.ToTable("UserRole", "dbo");
                m.MapLeftKey("RoleKey");
                m.MapRightKey("UserKey");
            });
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
