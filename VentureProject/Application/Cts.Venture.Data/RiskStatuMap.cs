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
    // RiskStatus
    internal partial class RiskStatuMap : EntityTypeConfiguration<RiskStatu>
    {
        public RiskStatuMap()
            : this("dbo")
        {
        }
 
        public RiskStatuMap(string schema)
        {
            ToTable(schema + ".RiskStatus");
            HasKey(x => x.RiskStatusId);

            Property(x => x.RiskStatusId).HasColumnName("RiskStatusID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.RiskStatus).HasColumnName("RiskStatus").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(25);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
