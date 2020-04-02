

namespace fBlockBuster.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblArticulo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblArticulo()
        {
            this.tblArticuloTransaccion = new HashSet<tblArticuloTransaccion>();
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
        public Nullable<decimal> Precio { get; set; }
    
        public virtual tblArticuloDetalle tblArticuloDetalle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblArticuloTransaccion> tblArticuloTransaccion { get; set; }
        public virtual tblGenero tblGenero { get; set; }
        public virtual tblTipo tblTipo { get; set; }
    }
}
