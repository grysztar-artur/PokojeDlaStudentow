//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjektPrototyp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Uczelnia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Uczelnia()
        {
            this.Kierunek = new HashSet<Kierunek>();
        }
    
        public int id_uczelni { get; set; }
        public string nazwa { get; set; }
        public int id_adresu { get; set; }
    
        public virtual Adres Adres { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kierunek> Kierunek { get; set; }
    }
}