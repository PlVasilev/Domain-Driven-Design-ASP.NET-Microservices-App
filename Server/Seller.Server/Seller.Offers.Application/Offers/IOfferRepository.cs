namespace Seller.Offers.Application.Offers
{
    using Seller.Offers.Domain.Offers.Models;
    using Seller.Shared.DDD.Application.Contracts;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Commands.Add;
    using Queries.Mine;
    using Queries.All;
    public interface IOfferRepository : IRepository<Offer>
    {
        Task<AddOfferOutputModel> Add(decimal price, string creatorId, string listingId, string title, string creatorName, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<AllOfferOutputModel>> All(string listingId, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<MineOfferOutputModel>> Mine(string userId, CancellationToken cancellationToken = default);
        Task<bool> Accept(string id, CancellationToken cancellationToken = default);
        Task<bool> Delete(string listingId, CancellationToken cancellationToken = default);
        Task<bool> DeleteOffer(string id, CancellationToken cancellationToken = default);
        Task<bool> Edit(string listingId, string title, CancellationToken cancellationToken = default);
        Task<int> GetOffersCount(string id, CancellationToken cancellationToken = default);
        Task<decimal> GetCurrentOffer(string creatorId, string listingId, CancellationToken cancellationToken = default);


        //Task<CarAd> Find(int id, CancellationToken cancellationToken = default);

        //Task<bool> Delete(int id, CancellationToken cancellationToken = default);

        //Task<Category> GetCategory(
        //    int categoryId,
        //    CancellationToken cancellationToken = default);

        //Task<Manufacturer> GetManufacturer(
        //    string manufacturer,
        //    CancellationToken cancellationToken = default);

        //Task<IEnumerable<TOutputModel>> GetCarAdListings<TOutputModel>(
        //    Specification<CarAd> carAdSpecification,
        //    Specification<Dealer> dealerSpecification,
        //    CarAdsSortOrder carAdsSortOrder,
        //    int skip = 0,
        //    int take = int.MaxValue,
        //    CancellationToken cancellationToken = default);

        //Task<CarAdDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);

        //Task<IEnumerable<GetCarAdCategoryOutputModel>> GetCarAdCategories(
        //    CancellationToken cancellationToken = default);

        //Task<int> Total(
        //    Specification<CarAd> carAdSpecification,
        //    Specification<Dealer> dealerSpecification, 
        //    CancellationToken cancellationToken = default);
    }
}
