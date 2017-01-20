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
    // Address
    internal partial class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
            : this("dbo")
        {
        }
 
        public AddressMap(string schema)
        {
            ToTable(schema + ".Address");
            HasKey(x => x.AddressKey);

            Property(x => x.AddressKey).HasColumnName("AddressKey").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Address1).HasColumnName("Address1").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.Address2).HasColumnName("Address2").IsOptional().IsFixedLength().HasColumnType("nchar").HasMaxLength(100);
            Property(x => x.City).HasColumnName("City").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.StateKey).HasColumnName("StateKey").IsOptional().HasColumnType("int");
            Property(x => x.ZipCode).HasColumnName("ZipCode").IsRequired().HasColumnType("nvarchar").HasMaxLength(15);

            // Foreign keys
            HasOptional(a => a.State).WithMany(b => b.Addresses).HasForeignKey(c => c.StateKey); // FK_Address_State
            HasMany(t => t.Users).WithMany(t => t.Addresses).Map(m => 
            {
                m.ToTable("UserAddress", "dbo");
                m.MapLeftKey("AddressKey");
                m.MapRightKey("UserKey");
            });
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
