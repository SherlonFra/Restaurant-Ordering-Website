using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManager.Models
{
    public class DeliveryPersonel
    {
        public int DeliveryPersonelId { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
