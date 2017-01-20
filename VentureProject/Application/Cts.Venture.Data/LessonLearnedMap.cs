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
    // LessonLearned
    internal partial class LessonLearnedMap : EntityTypeConfiguration<LessonLearned>
    {
        public LessonLearnedMap()
            : this("dbo")
        {
        }
 
        public LessonLearnedMap(string schema)
        {
            ToTable(schema + ".LessonLearned");
            HasKey(x => x.LessonLearnedId);

            Property(x => x.LessonLearnedId).HasColumnName("LessonLearnedID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Description).HasColumnName("Description").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Recommendation).HasColumnName("Recommendation").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.LessonLearnedTypeId).HasColumnName("LessonLearnedTypeID").IsOptional().HasColumnType("int");
            Property(x => x.ProjectId).HasColumnName("ProjectID").IsOptional().HasColumnType("int");

            // Foreign keys
            HasOptional(a => a.LessonLearnedType).WithMany(b => b.LessonLearneds).HasForeignKey(c => c.LessonLearnedTypeId); // LessonLearnedType_LessonLearned_FK1
            HasOptional(a => a.Project).WithMany(b => b.LessonLearneds).HasForeignKey(c => c.ProjectId); // Project_LessonLearned_FK1
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
