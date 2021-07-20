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

       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Quantity { get; set; }

        public decimal Total { get; set; }

        public decimal TotalPrice {get; set; }
    }
}
