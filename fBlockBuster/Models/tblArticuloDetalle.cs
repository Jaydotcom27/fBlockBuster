

namespace fBlockBuster.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblArticuloDetalle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblArticuloDetalle()
        {
            this.tblArticulo = new HashSet<tblArticulo>();
        }
    
        public int idArticuloDetalle { get; set; }
        public int idRating { get; set; }
        public string Productor { get; set; }
        public string Director { get; set; }
        public string Estudio { get; set; }
        public string Formato { get; set; }
        public string Idioma { get; set; }
        public string Subtitulos { get; set; }
        public Nullable<decimal> Nota { get; set; }
        public Nullable<System.DateTime> Año { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblArticulo> tblArticulo { get; set; }
        public virtual tblRating tblRating { get; set; }
    }
}
