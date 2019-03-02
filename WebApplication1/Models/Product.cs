using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RetailQuantity { get; set; }
        public int RetailPrice { get; set; }
        public double PromoQuantity { get; set; }
        public int PromoPrice { get; set; }
        public string PromoText { get; set; }
        public string Unit { get; set; }
    }
}