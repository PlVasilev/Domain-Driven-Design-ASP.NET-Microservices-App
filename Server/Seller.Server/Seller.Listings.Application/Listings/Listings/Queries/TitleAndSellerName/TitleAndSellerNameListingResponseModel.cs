namespace Seller.Listings.Application.Listings.Listings.Queries.TitleAndSellerName
{
    public class TitleAndSellerNameListingResponseModel
    {
        public TitleAndSellerNameListingResponseModel()
        {
            
        }

        public TitleAndSellerNameListingResponseModel(string sellerName, string title)
        {
            SellerName = sellerName;
            Title = title;
        }

        public string? SellerName { get; set; }
        public string? Title { get; set; }
    }
}
