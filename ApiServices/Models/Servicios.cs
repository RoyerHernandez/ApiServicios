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
    
    public partial class Servicios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Servicios()
        {
            this.ServiciosEmpresa = new HashSet<ServiciosEmpresa>();
        }
    
        public int Id_Servicio { get; set; }
        public string Nombre_Servicio { get; set; }
        public Nullable<int> Id_TipoServicio { get; set; }
        public Nullable<int> Id_estado { get; set; }
        public Nullable<System.DateTime> Fecha_Ingreso { get; set; }
        public string Usuario_Ingreso { get; set; }
        public Nullable<System.DateTime> Fecha_Modificacion { get; set; }
        public string Usuario_Modifica { get; set; }
    
        public virtual Estados Estados { get; set; }
        public virtual TiposServicios TiposServicios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiciosEmpresa> ServiciosEmpresa { get; set; }
    }
}
