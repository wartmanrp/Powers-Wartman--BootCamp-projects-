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
    // aspnet_Users
    internal partial class AspnetUserMap : EntityTypeConfiguration<AspnetUser>
    {
        public AspnetUserMap()
            : this("dbo")
        {
        }
 
        public AspnetUserMap(string schema)
        {
            ToTable(schema + ".aspnet_Users");
            HasKey(x => x.UserId);

            Property(x => x.ApplicationId).HasColumnName("ApplicationId").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.UserId).HasColumnName("UserId").IsRequired().HasColumnType("uniqueidentifier").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.UserName).HasColumnName("UserName").IsRequired().HasColumnType("nvarchar").HasMaxLength(256);
            Property(x => x.LoweredUserName).HasColumnName("LoweredUserName").IsRequired().HasColumnType("nvarchar").HasMaxLength(256);
            Property(x => x.MobileAlias).HasColumnName("MobileAlias").IsOptional().HasColumnType("nvarchar").HasMaxLength(16);
            Property(x => x.IsAnonymous).HasColumnName("IsAnonymous").IsRequired().HasColumnType("bit");
            Property(x => x.LastActivityDate).HasColumnName("LastActivityDate").IsRequired().HasColumnType("datetime");

            // Foreign keys
            HasRequired(a => a.AspnetApplication).WithMany(b => b.AspnetUsers).HasForeignKey(c => c.ApplicationId); // FK__aspnet_Us__Appli__76969D2E
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
