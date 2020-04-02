
namespace fBlockBuster.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblGenero
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblGenero()
        {
            this.tblArticulo = new HashSet<tblArticulo>();
        }
    
        public int idGenero { get; set; }
        public string Genero { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblArticulo> tblArticulo { get; set; }
    }
}
