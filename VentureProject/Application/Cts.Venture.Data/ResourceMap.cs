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
    // Resource
    internal partial class ResourceMap : EntityTypeConfiguration<Resource>
    {
        public ResourceMap()
            : this("dbo")
        {
        }
 
        public ResourceMap(string schema)
        {
            ToTable(schema + ".Resource");
            HasKey(x => x.ResourceId);

            Property(x => x.ResourceId).HasColumnName("ResourceID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Resource_).HasColumnName("Resource").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Email).HasColumnName("Email").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(75);
            Property(x => x.Phone).HasColumnName("Phone").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(20);
            Property(x => x.UserId).HasColumnName("UserID").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(25);
            Property(x => x.Deleted).HasColumnName("Deleted").IsRequired().HasColumnType("bit");
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
