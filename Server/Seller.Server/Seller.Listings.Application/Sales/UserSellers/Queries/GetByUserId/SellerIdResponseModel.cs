namespace Seller.Listings.Application.Sales.UserSellers.Queries.GetByUserId
{
    public class SellerIdResponseModel
    {
        public SellerIdResponseModel()
        {
            
        }

        public SellerIdResponseModel(string id)
        {
            this.Id = id;
        }
        public string? Id { get; }
    }
}
