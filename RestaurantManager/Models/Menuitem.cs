using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManager.Models
{
    public class Menuitem
    {
        
        public int MenuItemId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1.0, 100.0)]

        public decimal Price { get; set; }

        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }
        
        public Category Category { get; set; }

        public List<ShoppingCart> ShoppingCarts { get; set; }



    }
}
