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
    // Probability
    internal partial class ProbabilityMap : EntityTypeConfiguration<Probability>
    {
        public ProbabilityMap()
            : this("dbo")
        {
        }
 
        public ProbabilityMap(string schema)
        {
            ToTable(schema + ".Probability");
            HasKey(x => x.ProbabilityId);

            Property(x => x.ProbabilityId).HasColumnName("ProbabilityID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Probability_).HasColumnName("Probability").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(25);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
