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
    
    public partial class Clientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clientes()
        {
            this.Citas = new HashSet<Citas>();
        }
    
        public int Id_Cliente { get; set; }
        public string Nombres_Cliente { get; set; }
        public string Apellidos_Cliente { get; set; }
        public Nullable<int> Id_Estado { get; set; }
        public string Login_Creacion { get; set; }
        public Nullable<System.DateTime> Fecha_creacion { get; set; }
        public string Login_Modificacion { get; set; }
        public Nullable<System.DateTime> Fecha_Modificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Citas> Citas { get; set; }
        public virtual Estados Estados { get; set; }
    }
}
