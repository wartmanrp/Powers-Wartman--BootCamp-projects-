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
    // State
    internal partial class StateMap : EntityTypeConfiguration<State>
    {
        public StateMap()
            : this("dbo")
        {
        }
 
        public StateMap(string schema)
        {
            ToTable(schema + ".State");
            HasKey(x => x.StateKey);

            Property(x => x.StateKey).HasColumnName("StateKey").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.StateName).HasColumnName("StateName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.StateAbbrv).HasColumnName("StateAbbrv").IsRequired().HasColumnType("nvarchar").HasMaxLength(5);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
