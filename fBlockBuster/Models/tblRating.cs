

namespace fBlockBuster.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblRating
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblRating()
        {
            this.tblArticuloDetalle = new HashSet<tblArticuloDetalle>();
        }
    
        public int idRating { get; set; }
        public string Rating { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblArticuloDetalle> tblArticuloDetalle { get; set; }
    }
}
