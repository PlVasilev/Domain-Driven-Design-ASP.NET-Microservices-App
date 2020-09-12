using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Seller.Offers.Features.Offer.Models
{
    public class OfferAddRequestModel
    {
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }
        [Required]
        public string CreatorId { get; set; }
        [Required]
        public string ListingId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string CreatorName { get; set; }

    }
}
    
