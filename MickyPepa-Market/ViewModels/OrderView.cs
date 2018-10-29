using MickyPepa_Market.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MickyPepa_Market.ViewModels
{
    public class OrderView
    {
        public Customer Customer { get; set; }
        public List<ProductOrder> Product { get; set; }
    }
}