using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            IEnumerable<Cart> cart = (IEnumerable<Cart>)Session["cart"];
            if (cart != null) { return View(cart); }
            else return View();
            
        }

        public ActionResult Buy(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<Product> products = db.Products.ToList();
            if (Session["cart"] == null)
            {
                List<Cart> cart = new List<Cart>();
                cart.Add(new Cart { ProductId = id, Product = products.Where(s=>s.Id == id).FirstOrDefault(), ProductQuantity = 1 });
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
                    cart.Add(new Cart { ProductId = id, Product = products.Where(s => s.Id == id).FirstOrDefault(), ProductQuantity = 1 });
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
                if (cart[i].ProductId.Equals(id))
                    return i;
            return -1;
        }
    }
}