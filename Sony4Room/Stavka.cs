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
    
    public partial class Stavka
    {
        public int IdStavka { get; set; }
        public Nullable<int> IdRacuna { get; set; }
        public Nullable<int> KomadaPica { get; set; }
        public Nullable<int> IdPica { get; set; }
    
        public virtual Pice Pice { get; set; }
        public virtual Racun Racun { get; set; }
    }
}
