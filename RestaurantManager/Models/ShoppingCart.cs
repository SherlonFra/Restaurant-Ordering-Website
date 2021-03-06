using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManager.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        [ForeignKey("AspNetUsers")]
        public int AspNetUserId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Purchased { get; set; }
        public bool IsActive { get; set; }
        public List<Menuitem> Items { get; set; }
    }
}