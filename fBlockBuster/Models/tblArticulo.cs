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
    
    public partial class tblArticulo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblArticulo()
        {
            this.tblTransaccion = new HashSet<tblTransaccion>();
        }
    
        public int idArticulo { get; set; }
        public int idArticuloDetalle { get; set; }
        public int idTipo { get; set; }
        public int idGenero { get; set; }
        public string Miniatura { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Nullable<System.TimeSpan> Duracion { get; set; }
        public Nullable<byte> Temporadas { get; set; }
        public Nullable<byte> Episodios { get; set; }
    
        public virtual tblArticuloDetalle tblArticuloDetalle { get; set; }
        public virtual tblGenero tblGenero { get; set; }
        public virtual tblTipo tblTipo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblTransaccion> tblTransaccion { get; set; }
    }
}
