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
    // IssueType
    internal partial class IssueTypeMap : EntityTypeConfiguration<IssueType>
    {
        public IssueTypeMap()
            : this("dbo")
        {
        }
 
        public IssueTypeMap(string schema)
        {
            ToTable(schema + ".IssueType");
            HasKey(x => x.IssueTypeId);

            Property(x => x.IssueTypeId).HasColumnName("IssueTypeID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.IssueType_).HasColumnName("IssueType").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(15);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
