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
    // ProjectConsensusRating
    internal partial class ProjectConsensusRatingMap : EntityTypeConfiguration<ProjectConsensusRating>
    {
        public ProjectConsensusRatingMap()
            : this("dbo")
        {
        }
 
        public ProjectConsensusRatingMap(string schema)
        {
            ToTable(schema + ".ProjectConsensusRating");
            HasKey(x => x.ProjectConsensusRatingId);

            Property(x => x.ProjectConsensusRatingId).HasColumnName("ProjectConsensusRatingID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.RatingCategoryId).HasColumnName("RatingCategoryID").IsRequired().HasColumnType("int");
            Property(x => x.ProjectId).HasColumnName("ProjectID").IsRequired().HasColumnType("int");
            Property(x => x.VeryDissatisfied).HasColumnName("VeryDissatisfied").IsRequired().HasColumnType("bit");
            Property(x => x.Dissatisfied).HasColumnName("Dissatisfied").IsRequired().HasColumnType("bit");
            Property(x => x.Neutral).HasColumnName("Neutral").IsRequired().HasColumnType("bit");
            Property(x => x.Satisfied).HasColumnName("Satisfied").IsRequired().HasColumnType("bit");
            Property(x => x.VerySatisfied).HasColumnName("VerySatisfied").IsRequired().HasColumnType("bit");

            // Foreign keys
            HasRequired(a => a.ConsensusRatingCategory).WithMany(b => b.ProjectConsensusRatings).HasForeignKey(c => c.RatingCategoryId); // ConsensusRatingCategory_ProjectConsensusRating_FK1
            HasRequired(a => a.Project).WithMany(b => b.ProjectConsensusRatings).HasForeignKey(c => c.ProjectId); // Project_ProjectConsensusRating_FK1
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
