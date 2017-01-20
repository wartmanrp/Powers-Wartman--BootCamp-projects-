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
    // Status
    internal partial class StatusMap : EntityTypeConfiguration<Status>
    {
        public StatusMap()
            : this("dbo")
        {
        }
 
        public StatusMap(string schema)
        {
            ToTable(schema + ".Status");
            HasKey(x => x.StatusId);

            Property(x => x.StatusId).HasColumnName("StatusID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Status_).HasColumnName("Status").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(25);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
