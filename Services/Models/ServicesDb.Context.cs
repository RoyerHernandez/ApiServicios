﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Services.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ServicesDbEntities : DbContext
    {
        public ServicesDbEntities()
            : base("name=ServicesDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<Puntos> Puntos { get; set; }
        public virtual DbSet<Citas> Citas { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Disponibilidad> Disponibilidad { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<EstadoCitas> EstadoCitas { get; set; }
        public virtual DbSet<Servicios> Servicios { get; set; }
        public virtual DbSet<ServiciosEmpresa> ServiciosEmpresa { get; set; }
        public virtual DbSet<ServiciosEmpresasPuntos> ServiciosEmpresasPuntos { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TipoCalificacion> TipoCalificacion { get; set; }
        public virtual DbSet<TiposDocumentos> TiposDocumentos { get; set; }
        public virtual DbSet<TiposServicios> TiposServicios { get; set; }
        public virtual DbSet<EmpleadosEmpresas> EmpleadosEmpresas { get; set; }
        public virtual DbSet<EmpleadosPuntos> EmpleadosPuntos { get; set; }
    }
}