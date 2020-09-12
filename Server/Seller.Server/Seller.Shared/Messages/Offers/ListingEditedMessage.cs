using System;
using System.Collections.Generic;
using System.Text;

namespace Seller.Shared.Messages.Offers
{
    public class ListingEditedMessage
    {
        public string ListingId { get; set; }
        public string Title { get; set; }
    }
}
