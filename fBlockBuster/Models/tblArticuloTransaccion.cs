

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
