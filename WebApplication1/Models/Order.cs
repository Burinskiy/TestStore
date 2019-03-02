using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public Order()
        {
            Carts = new List<Cart>();
        }
    }
}