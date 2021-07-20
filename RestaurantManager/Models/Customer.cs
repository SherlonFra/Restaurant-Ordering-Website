using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManager.Models
{
    public class Customer
    {
       
        public int CustomerId { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }
        
        [Required]
        public int TelephoneNumber { get; set; }
    }
}
