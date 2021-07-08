using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManager.Models
{
    public class DeliveryOption
    {
        public int DeliveryOptionId { get; set; }
        public int OrderId { get; set; }


        

        [Required]
        public string DeliveryType { get; set; }
    }
}
