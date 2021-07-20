using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using RestaurantManager.Models;

namespace RestaurantManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet <Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Menuitem> Menuitems { get; set; }

        public DbSet<DeliveryPersonel> DeliveryPersonels { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<DeliveryOption> DeliveryOptions { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
