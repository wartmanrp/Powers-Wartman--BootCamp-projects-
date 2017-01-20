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
    public partial class VENTUREDbContext : DbContext, IVENTUREDbContext
    {
        public DbSet<Address> Addresses { get; set; } // Address
        public DbSet<Role> Roles { get; set; } // Role
        public DbSet<State> States { get; set; } // State
        public DbSet<User> Users { get; set; } // User
        
        static VENTUREDbContext()
        {
            System.Data.Entity.Database.SetInitializer<VENTUREDbContext>(null);
        }

        public VENTUREDbContext()
            : base("Name=VENTUREDbContext")
        {
            InitializePartial();
        }

        public VENTUREDbContext(string connectionString) : base(connectionString)
        {
            InitializePartial();
        }

        public VENTUREDbContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model) : base(connectionString, model)
        {
            InitializePartial();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new StateMap());
            modelBuilder.Configurations.Add(new UserMap());

            OnModelCreatingPartial(modelBuilder);
        }

        public static DbModelBuilder CreateModel(DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new AddressMap(schema));
            modelBuilder.Configurations.Add(new RoleMap(schema));
            modelBuilder.Configurations.Add(new StateMap(schema));
            modelBuilder.Configurations.Add(new UserMap(schema));
            return modelBuilder;
        }

        partial void InitializePartial();
        partial void OnModelCreatingPartial(DbModelBuilder modelBuilder);
    }
}
