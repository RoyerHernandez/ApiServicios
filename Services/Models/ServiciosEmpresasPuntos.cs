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
    
    public partial class ServiciosEmpresasPuntos
    {
        public int Id_ServicioEmpresaPunto { get; set; }
        public Nullable<int> Id_ServicioEmpresa { get; set; }
        public string Detalles { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public Nullable<int> Id_Estado { get; set; }
        public Nullable<System.DateTime> Fecha_Ingreso { get; set; }
        public string Usuario_Ingreso { get; set; }
        public Nullable<System.DateTime> Fecha_Modificacion { get; set; }
        public string Usuario_Modifica { get; set; }
    
        public virtual Estados Estados { get; set; }
        public virtual ServiciosEmpresa ServiciosEmpresa { get; set; }
    }
}
