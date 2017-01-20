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
    // ProjectRatingHistory
    internal partial class ProjectRatingHistoryMap : EntityTypeConfiguration<ProjectRatingHistory>
    {
        public ProjectRatingHistoryMap()
            : this("dbo")
        {
        }
 
        public ProjectRatingHistoryMap(string schema)
        {
            ToTable(schema + ".ProjectRatingHistory");
            HasKey(x => x.ProjectRatingHistoryId);

            Property(x => x.ProjectRatingHistoryId).HasColumnName("ProjectRatingHistoryID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProjectRatingTextId).HasColumnName("ProjectRatingTextId").IsOptional().HasColumnType("int");
            Property(x => x.ProjectId).HasColumnName("ProjectID").IsOptional().HasColumnType("int");
            Property(x => x.ProjectRatingId).HasColumnName("ProjectRatingID").IsOptional().HasColumnType("int");
            Property(x => x.ProjectRatingDate).HasColumnName("ProjectRatingDate").IsOptional().HasColumnType("datetime");

            // Foreign keys
            HasOptional(a => a.Project).WithMany(b => b.ProjectRatingHistories).HasForeignKey(c => c.ProjectId); // Project_ProjectRatingHistory_FK1
            HasOptional(a => a.ProjectRating).WithMany(b => b.ProjectRatingHistories).HasForeignKey(c => c.ProjectRatingId); // ProjectRating_ProjectRatingHistory_FK1
            HasOptional(a => a.ProjectRatingText).WithMany(b => b.ProjectRatingHistories).HasForeignKey(c => c.ProjectRatingTextId); // ProjectRatingText_ProjectRatingHistory_FK1
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
