using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManager.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public decimal Total { get; set; }

        public decimal TotalPrice {get; set; }
    }
}
