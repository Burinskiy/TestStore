using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class AppDbInitialize : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            Product t = new Product { Name = "Tangerines", PromoPrice = 80, PromoQuantity = 3, RetailPrice = 30, RetailQuantity = 1, PromoText = "3 kg for 80 UAH", Unit = "Kg" };

            Product h = new Product { Name = "Honey", PromoPrice = 220, PromoQuantity = 2.5, RetailPrice = 100, RetailQuantity = 1, PromoText = "2,5 l for 220 UAH", Unit = "l" };

            Product c = new Product { Name = "Cables", PromoPrice = 85, PromoQuantity = 10, RetailPrice = 10, RetailQuantity = 1, PromoText = "10 m for 85 UAH", Unit = "m" };
            context.Products.Add(t);
            context.Products.Add(h);
            context.Products.Add(c);
            //Roles
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var role1 = new IdentityRole { Name = "StoreOwner" };
            var role2 = new IdentityRole { Name = "Customer" };

            roleManager.Create(role1);
            roleManager.Create(role2);

            var owner = new ApplicationUser { Email = "testowner@gmail.com", UserName = "testowner@gmail.com" };
            string password = "12345678";
            var ownerresult = userManager.Create(owner, password);

            var user = new ApplicationUser { Email = "testcustomer@gmail.com", UserName = "testcustomer@gmail.com" };
            string userPassword = "12345678";
            var userResult = userManager.Create(user, userPassword);

            if ((ownerresult.Succeeded) && (userResult.Succeeded))
            {
                userManager.AddToRole(owner.Id, role1.Name);
                userManager.AddToRole(owner.Id, role2.Name);
                userManager.AddToRole(user.Id, role2.Name);
            }

            //Order o1 = new Order { UserId = user.Id, CreateDate = DateTime.Now };

            //Order o2 = new Order { UserId = user.Id, CreateDate = DateTime.Now.AddHours(1) };

            //Order o3 = new Order { UserId = user.Id, CreateDate = DateTime.Now.AddMinutes(20) };
            //context.Orders.Add(o1);
            //context.Orders.Add(o2);

            //Cart c1 = new Cart { Product = t, ProductQuantity = 1};

            //Cart c2 = new Cart { Product = c, ProductQuantity = 5};

            //Cart c3 = new Cart { Product = h, ProductQuantity = 1};
            //context.Carts.Add(c1);
            //context.Carts.Add(c2);
            //context.Carts.Add(c3);

            base.Seed(context);
        }
    }
}