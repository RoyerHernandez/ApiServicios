//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Empleados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empleados()
        {
            this.Citas = new HashSet<Citas>();
            this.Disponibilidad = new HashSet<Disponibilidad>();
            this.EmpleadosEmpresas = new HashSet<EmpleadosEmpresas>();
            this.EmpleadosPuntos = new HashSet<EmpleadosPuntos>();
        }
    
        public int Id_empleado { get; set; }
        public Nullable<int> Id_TipoDocumento { get; set; }
        public Nullable<decimal> NoDocumento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public Nullable<decimal> Telefono { get; set; }
        public string Correo { get; set; }
        public Nullable<int> Id_Estado { get; set; }
        public string Fotos { get; set; }
        public string RedesSociales { get; set; }
        public string Login_Creacion { get; set; }
        public Nullable<System.DateTime> Fecha_creacion { get; set; }
        public string Login_Modificacion { get; set; }
        public Nullable<System.DateTime> Fecha_Modificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Citas> Citas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Disponibilidad> Disponibilidad { get; set; }
        public virtual Estados Estados { get; set; }
        public virtual TiposDocumentos TiposDocumentos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmpleadosEmpresas> EmpleadosEmpresas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmpleadosPuntos> EmpleadosPuntos { get; set; }
    }
}
