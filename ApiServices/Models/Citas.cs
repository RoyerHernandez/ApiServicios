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
    
    public partial class Citas
    {
        public int Id_Cita { get; set; }
        public Nullable<int> Id_Empresa { get; set; }
        public Nullable<int> Id_Punto { get; set; }
        public Nullable<int> Id_Empleado { get; set; }
        public Nullable<int> Id_Cliente { get; set; }
        public Nullable<int> Id_EstadoCita { get; set; }
        public Nullable<int> Id_Disponibilidad { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<System.TimeSpan> Hora_Inicial { get; set; }
        public Nullable<System.TimeSpan> Hora_fina { get; set; }
        public string Login_Creacion { get; set; }
        public Nullable<System.DateTime> Fecha_creacion { get; set; }
        public string Login_Modificacion { get; set; }
        public Nullable<System.DateTime> Fecha_Modificacion { get; set; }
    
        public virtual Clientes Clientes { get; set; }
        public virtual Disponibilidad Disponibilidad { get; set; }
        public virtual Empleados Empleados { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual EstadoCitas EstadoCitas { get; set; }
        public virtual Puntos Puntos { get; set; }
    }
}
