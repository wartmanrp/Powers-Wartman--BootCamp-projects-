// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
// TargetFrameworkVersion = 4.6
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using System;
using Cts.Venture.Domain;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.ComponentModel.DataAnnotations;

namespace Cts.Venture.Domain
{
    // FinancialInformation
    public partial class FinancialInformation
    {

        public int FinancialInformationId { get; set; } // FinancialInformationID (Primary key)

        public decimal? BaselineCapital { get; set; } // BaselineCapital

        public decimal? ApprovedCapital { get; set; } // ApprovedCapital

        public decimal? CapitalSpent { get; set; } // CapitalSpent

        public decimal? PendingCapital { get; set; } // PendingCapital

        public decimal? BaselineExpense { get; set; } // BaselineExpense

        public decimal? ApprovedExpense { get; set; } // ApprovedExpense

        public decimal? ExpenseSpent { get; set; } // ExpenseSpent

        public decimal? PendingExpense { get; set; } // PendingExpense

        public decimal? BaselineCap { get; set; } // BaselineCap

        public decimal? ApprovedCap { get; set; } // ApprovedCap

        public decimal? CapSpent { get; set; } // CapSpent

        public decimal? CumulativeNetIncome { get; set; } // CumulativeNetIncome

        public decimal? CumalativeNeiImpact { get; set; } // CumalativeNEIImpact

        public string CostCenter { get; set; } // CostCenter

        public int ProjectId { get; set; } // ProjectID

        public bool Active { get; set; } // Active

        public DateTime? DateCreated { get; set; } // DateCreated

        // Foreign keys
        public virtual Project Project { get; set; } // Project_FinancialInformation_FK1
        
        public FinancialInformation()
        {
            Active = true;
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
