using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MickyPepa_Market.Models
{
    public class Order
    {
        [Key]
        public Int32 OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public Int32 CustomerID { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}