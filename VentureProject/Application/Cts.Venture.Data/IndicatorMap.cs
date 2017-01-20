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
    // Indicator
    internal partial class IndicatorMap : EntityTypeConfiguration<Indicator>
    {
        public IndicatorMap()
            : this("dbo")
        {
        }
 
        public IndicatorMap(string schema)
        {
            ToTable(schema + ".Indicator");
            HasKey(x => x.IndicatorId);

            Property(x => x.IndicatorId).HasColumnName("IndicatorID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProjectIndicator).HasColumnName("ProjectIndicator").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.SortNumber).HasColumnName("SortNumber").IsRequired().HasColumnType("int");
            Property(x => x.ProjectStatusId).HasColumnName("ProjectStatusID").IsOptional().HasColumnType("int");
            Property(x => x.Deleted).HasColumnName("Deleted").IsRequired().HasColumnType("bit");

            // Foreign keys
            HasOptional(a => a.Status).WithMany(b => b.Indicators).HasForeignKey(c => c.ProjectStatusId); // Status_Indicator_FK1
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
