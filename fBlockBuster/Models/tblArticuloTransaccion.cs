//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace fBlockBuster.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblArticuloTransaccion
    {
        public int idArticuloTransaccion { get; set; }
        public int idArticulo { get; set; }
        public int idTransaccion { get; set; }
    
        public virtual tblArticulo tblArticulo { get; set; }
        public virtual tblTransaccion tblTransaccion { get; set; }
    }
}