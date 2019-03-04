using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        ApplicationDbContext db = new ApplicationDbContext();
        [Authorize(Roles ="StoreOwner")]
        public ActionResult Index()
        {
            IEnumerable<Order> orders = db.Orders.Include(p=>p.Carts);
            return View(orders);
        }

        // GET: Orders/Details/5
        [Authorize(Roles = "StoreOwner")]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Orders/Create
        
        public ActionResult SaveOrder()
        {
            List<Cart> carts = (List<Cart>)Session["cart"];
            foreach (Cart cart in carts)
            {
                db.Carts.Add(cart);
            }
            Order order = new Order { CreateDate = DateTime.Now, UserId = User.Identity.GetUserId(), Carts = carts};
            db.Orders.Add(order);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        // POST: Orders/Create
        [HttpPost]
        [Authorize(Roles = "StoreOwner")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Orders/Edit/5
        [Authorize(Roles = "StoreOwner")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [Authorize(Roles = "StoreOwner")]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Orders/Delete/5
        [Authorize(Roles = "StoreOwner")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Orders/Delete/5
        [HttpPost]
        [Authorize(Roles = "StoreOwner")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
