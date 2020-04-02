

namespace fBlockBuster.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblEstado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblEstado()
        {
            this.tblTransaccion = new HashSet<tblTransaccion>();
        }
    
        public int idEstado { get; set; }
        public string Estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblTransaccion> tblTransaccion { get; set; }
    }
}
