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
    
    public partial class EmpleadosEmpresas
    {
        public int Id_EmpleadosEmpresas { get; set; }
        public Nullable<int> Id_Empresa { get; set; }
        public Nullable<int> Id_Empleado { get; set; }
        public Nullable<int> Id_Estado { get; set; }
        public string Login_Creacion { get; set; }
        public Nullable<System.DateTime> Fecha_creacion { get; set; }
        public string Login_Modificacion { get; set; }
        public Nullable<System.DateTime> Fecha_Modificacion { get; set; }
    
        public virtual Empleados Empleados { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual Estados Estados { get; set; }
    }
}
