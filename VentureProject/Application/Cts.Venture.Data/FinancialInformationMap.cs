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
    // FinancialInformation
    internal partial class FinancialInformationMap : EntityTypeConfiguration<FinancialInformation>
    {
        public FinancialInformationMap()
            : this("dbo")
        {
        }
 
        public FinancialInformationMap(string schema)
        {
            ToTable(schema + ".FinancialInformation");
            HasKey(x => x.FinancialInformationId);

            Property(x => x.FinancialInformationId).HasColumnName("FinancialInformationID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.BaselineCapital).HasColumnName("BaselineCapital").IsOptional().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.ApprovedCapital).HasColumnName("ApprovedCapital").IsOptional().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.CapitalSpent).HasColumnName("CapitalSpent").IsOptional().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.PendingCapital).HasColumnName("PendingCapital").IsOptional().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.BaselineExpense).HasColumnName("BaselineExpense").IsOptional().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.ApprovedExpense).HasColumnName("ApprovedExpense").IsOptional().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.ExpenseSpent).HasColumnName("ExpenseSpent").IsOptional().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.PendingExpense).HasColumnName("PendingExpense").IsOptional().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.BaselineCap).HasColumnName("BaselineCap").IsOptional().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.ApprovedCap).HasColumnName("ApprovedCap").IsOptional().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.CapSpent).HasColumnName("CapSpent").IsOptional().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.CumulativeNetIncome).HasColumnName("CumulativeNetIncome").IsOptional().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.CumalativeNeiImpact).HasColumnName("CumalativeNEIImpact").IsOptional().HasColumnType("money").HasPrecision(19,4);
            Property(x => x.CostCenter).HasColumnName("CostCenter").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(25);
            Property(x => x.ProjectId).HasColumnName("ProjectID").IsRequired().HasColumnType("int");
            Property(x => x.Active).HasColumnName("Active").IsRequired().HasColumnType("bit");
            Property(x => x.DateCreated).HasColumnName("DateCreated").IsOptional().HasColumnType("datetime");

            // Foreign keys
            HasRequired(a => a.Project).WithMany(b => b.FinancialInformations).HasForeignKey(c => c.ProjectId); // Project_FinancialInformation_FK1
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
