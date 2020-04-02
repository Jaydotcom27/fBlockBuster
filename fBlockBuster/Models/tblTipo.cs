
namespace fBlockBuster.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblTipo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblTipo()
        {
            this.tblArticulo = new HashSet<tblArticulo>();
            this.tblTransaccion = new HashSet<tblTransaccion>();
            this.tblUsuario = new HashSet<tblUsuario>();
        }
    
        public int idTipo { get; set; }
        public string Descripcion { get; set; }
        public string TipoTipo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblArticulo> tblArticulo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblTransaccion> tblTransaccion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblUsuario> tblUsuario { get; set; }
    }
}
