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
    
    public partial class Adres
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Adres()
        {
            this.Budynek = new HashSet<Budynek>();
            this.Opiekun = new HashSet<Opiekun>();
            this.Student = new HashSet<Student>();
            this.Uczelnia = new HashSet<Uczelnia>();
        }
    
        public int id_adresu { get; set; }
        public string miejscowosc { get; set; }
        public string poczta { get; set; }
        public string kod_pocztowy { get; set; }
        public string ulica { get; set; }
        public string numer_domu { get; set; }
        public string numer_lokalu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Budynek> Budynek { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Opiekun> Opiekun { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Student { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Uczelnia> Uczelnia { get; set; }
    }
}
