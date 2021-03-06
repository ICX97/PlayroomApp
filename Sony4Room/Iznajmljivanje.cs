//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sony4Room
{
    using System;
    using System.Collections.Generic;
    
    public partial class Iznajmljivanje
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Iznajmljivanje()
        {
            this.Racuns = new HashSet<Racun>();
        }
    
        public int IdIznajmljivanje { get; set; }
        public Nullable<System.DateTime> Datum { get; set; }
        public Nullable<System.DateTime> VremePocetka { get; set; }
        public Nullable<System.DateTime> VremeZavrsavanja { get; set; }
        public Nullable<int> IdSlusalica { get; set; }
        public Nullable<int> IdJoypeda { get; set; }
        public Nullable<int> IdClan { get; set; }
        public Nullable<int> IdRadnika { get; set; }
        public Nullable<int> IdKonzole { get; set; }
    
        public virtual Clan Clan { get; set; }
        public virtual Joyped Joyped { get; set; }
        public virtual Radnik Radnik { get; set; }
        public virtual Slusalouse Slusalouse { get; set; }
        public virtual Konzola Konzola { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Racun> Racuns { get; set; }
    }
}
