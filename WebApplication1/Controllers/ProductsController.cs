using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: Products
        [Authorize(Roles = "Customer")]
        public ActionResult Index()
        {
            IEnumerable<Product> products = context.Products;
            return View(products);
        }

        // GET: Products/Details/5
        [Authorize(Roles = "Customer")]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        [Authorize(Roles = "StoreOwner")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [Authorize(Roles = "StoreOwner")]
        [HttpPost]
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

        // GET: Products/Edit/5
        [Authorize(Roles = "StoreOwner")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
        [Authorize(Roles = "StoreOwner")]
        [HttpPost]
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

        // GET: Products/Delete/5
        [Authorize(Roles = "StoreOwner")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [Authorize(Roles = "StoreOwner")]
        [HttpPost]
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
