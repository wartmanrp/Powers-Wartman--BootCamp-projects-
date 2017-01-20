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
    // User
    internal partial class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
            : this("dbo")
        {
        }
 
        public UserMap(string schema)
        {
            ToTable(schema + ".User");
            HasKey(x => x.UserKey);

            Property(x => x.UserKey).HasColumnName("UserKey").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Username).HasColumnName("Username").IsRequired().HasColumnType("nvarchar").HasMaxLength(30);
            Property(x => x.Password).HasColumnName("Password").IsRequired().HasColumnType("nvarchar").HasMaxLength(250);
            Property(x => x.FirstName).HasColumnName("FirstName").IsRequired().HasColumnType("nvarchar").HasMaxLength(25);
            Property(x => x.MiddleName).HasColumnName("MiddleName").IsOptional().HasColumnType("nvarchar").HasMaxLength(25);
            Property(x => x.LastName).HasColumnName("LastName").IsRequired().HasColumnType("nvarchar").HasMaxLength(35);
            Property(x => x.Phone).HasColumnName("Phone").IsRequired().HasColumnType("nvarchar").HasMaxLength(20);
            Property(x => x.DateOfBirth).HasColumnName("DateOfBirth").IsOptional().HasColumnType("date");
            Property(x => x.Email).HasColumnName("Email").IsOptional().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.SupervisorUserKey).HasColumnName("SupervisorUserKey").IsOptional().HasColumnType("int");

            // Foreign keys
            HasOptional(a => a.User_SupervisorUserKey).WithMany(b => b.Users).HasForeignKey(c => c.SupervisorUserKey); // FK_User_Supervisor
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
