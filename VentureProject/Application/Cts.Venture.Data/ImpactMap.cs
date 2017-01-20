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
    // Impact
    internal partial class ImpactMap : EntityTypeConfiguration<Impact>
    {
        public ImpactMap()
            : this("dbo")
        {
        }
 
        public ImpactMap(string schema)
        {
            ToTable(schema + ".Impact");
            HasKey(x => x.ImpactId);

            Property(x => x.ImpactId).HasColumnName("ImpactID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Impact_).HasColumnName("Impact").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(25);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}