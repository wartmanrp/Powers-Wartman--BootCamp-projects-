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
    // aspnet_Applications
    internal partial class AspnetApplicationMap : EntityTypeConfiguration<AspnetApplication>
    {
        public AspnetApplicationMap()
            : this("dbo")
        {
        }
 
        public AspnetApplicationMap(string schema)
        {
            ToTable(schema + ".aspnet_Applications");
            HasKey(x => x.ApplicationId);

            Property(x => x.ApplicationName).HasColumnName("ApplicationName").IsRequired().HasColumnType("nvarchar").HasMaxLength(256);
            Property(x => x.LoweredApplicationName).HasColumnName("LoweredApplicationName").IsRequired().HasColumnType("nvarchar").HasMaxLength(256);
            Property(x => x.ApplicationId).HasColumnName("ApplicationId").IsRequired().HasColumnType("uniqueidentifier").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Description).HasColumnName("Description").IsOptional().HasColumnType("nvarchar").HasMaxLength(256);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
