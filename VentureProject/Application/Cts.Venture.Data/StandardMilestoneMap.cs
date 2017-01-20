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
    // StandardMilestone
    internal partial class StandardMilestoneMap : EntityTypeConfiguration<StandardMilestone>
    {
        public StandardMilestoneMap()
            : this("dbo")
        {
        }
 
        public StandardMilestoneMap(string schema)
        {
            ToTable(schema + ".StandardMilestone");
            HasKey(x => x.StandardMilestoneId);

            Property(x => x.StandardMilestoneId).HasColumnName("StandardMilestoneID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.StandardMilestone_).HasColumnName("StandardMilestone").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.BaselinePoints).HasColumnName("BaselinePoints").IsOptional().HasColumnType("int");
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
