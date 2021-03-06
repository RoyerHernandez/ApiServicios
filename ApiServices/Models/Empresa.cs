//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiServices.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Empresa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empresa()
        {
            this.Citas = new HashSet<Citas>();
            this.Disponibilidad = new HashSet<Disponibilidad>();
            this.EmpleadosEmpresas = new HashSet<EmpleadosEmpresas>();
            this.Puntos = new HashSet<Puntos>();
        }
    
        public int Id_Empresa { get; set; }
        public string Nombre_Empresa { get; set; }
        public Nullable<int> Nit { get; set; }
        public string Direccion { get; set; }
        public Nullable<int> Telefono { get; set; }
        public Nullable<int> Id_Estado { get; set; }
        public string Id_redesSociales { get; set; }
        public string Login_Creacion { get; set; }
        public Nullable<System.DateTime> Fecha_creacion { get; set; }
        public string Login_Modificacion { get; set; }
        public Nullable<System.DateTime> Fecha_Modificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Citas> Citas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Disponibilidad> Disponibilidad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmpleadosEmpresas> EmpleadosEmpresas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Puntos> Puntos { get; set; }
        public virtual Estados Estados { get; set; }
    }
}
