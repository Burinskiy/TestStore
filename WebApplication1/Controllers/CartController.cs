using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            IEnumerable<Cart> cart = (List<Cart>)Session["cart"];
            return View(cart);
        }

        public ActionResult Buy(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<Product> products = db.Products.ToList();
            if (Session["cart"] == null)
            {
                List<Cart> cart = new List<Cart>();
                cart.Add(new Cart { Product = products.Where(s => s.Id == id).FirstOrDefault(), ProductQuantity = 1 });
                Session["cart"] = cart;
            }
            else
            {
                List<Cart> cart = (List<Cart>)Session["cart"];
                int index = Exist(id);
                if (index != -1)
                {
                    cart[index].ProductQuantity++;
                }
                else
                {
                    cart.Add(new Cart { Product = products.Where(p => p.Id == id).FirstOrDefault(), ProductQuantity = 1 });
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("Index", "Products");
        }

        public ActionResult Delete(int id)
        {
            List<Cart> cart = (List<Cart>)Session["cart"];
            int index = Exist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }

        private int Exist(int id)
        {
            List<Cart> cart = (List<Cart>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.Id.Equals(id))
                    return i;
            return -1;
        }
    }
}