using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MickyPepa_Market.Models
{
    public class SupplierProduct
    {
        [Key]
        public Int32 SupplierProductID { get; set; }
        public Int32 SupplierID { get; set; }
        public Int32 ProductID { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual Product Product { get; set; }
    }
}