//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ParkingLot.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ParkingSpot
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ParkingSpot()
        {
            this.LotStays = new HashSet<LotStay>();
        }
    
        public int ParkingSpotKey { get; set; }
        public string ParkingSpotNumber { get; set; }
        public int ParkingLotKey { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LotStay> LotStays { get; set; }
        public virtual ParkingLot ParkingLot { get; set; }
    }
}
