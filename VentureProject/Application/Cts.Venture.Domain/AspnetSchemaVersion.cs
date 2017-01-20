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
    // aspnet_SchemaVersions
    public partial class AspnetSchemaVersion
    {

        public string Feature { get; set; } // Feature (Primary key)

        public string CompatibleSchemaVersion { get; set; } // CompatibleSchemaVersion (Primary key)

        public bool IsCurrentVersion { get; set; } // IsCurrentVersion
        
        public AspnetSchemaVersion()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
