﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PokojeDlaStudentowEntities : DbContext
    {
        public PokojeDlaStudentowEntities()
            : base("name=PokojeDlaStudentowEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Adres> Adres { get; set; }
        public virtual DbSet<Budynek> Budynek { get; set; }
        public virtual DbSet<Kierunek> Kierunek { get; set; }
        public virtual DbSet<Opiekun> Opiekun { get; set; }
        public virtual DbSet<Pokoj> Pokoj { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Uczelnia> Uczelnia { get; set; }
    }
}
