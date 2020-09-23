using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Seller.Offers.Application.Offers;
using Seller.Offers.Application.Offers.Commands.Add;
using Seller.Offers.Application.Offers.Queries.All;
using Seller.Offers.Application.Offers.Queries.Mine;
using Seller.Offers.Domain.Offers.Models;
using Seller.Shared.DDD.Domain;
using Seller.Shared.DDD.Infrastructure.Persistence;

namespace Seller.Offers.Infrastructure.Offers.Repositories
{
    internal class OfferRepository : Common.Persistence.DataRepository<IOfferDbContext, Offer>, IOfferRepository
    {
        private readonly IMapper mapper;

        public OfferRepository(IOfferDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<AddOfferOutputModel> Add(decimal price, string creatorId, string listingId, string title, string creatorName,
            CancellationToken cancellationToken = default)
        {
            var offer = Data.Offers.FirstOrDefaultAsync(x =>
                      x.CreatorId == creatorId &&
                       x.ListingId == listingId &&
                        x.IsAccepted == false, cancellationToken: cancellationToken).Result;
            
            if (offer != null)
            {
                offer.UpdatePrice(price);
                await this.Save(offer, cancellationToken);
                return new AddOfferOutputModel(
                    offer.Id, offer.ListingId, offer.Price, offer.Created, offer.CreatorId, offer.IsAccepted, offer.Title, offer.CreatorName);
            }

            return new AddOfferOutputModel();
        }

        public Task<List<AllOfferOutputModel>> All(string listingId, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<MineOfferOutputModel>> Mine(string userId, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Accept(string id, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(string listingId, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteOffer(string id, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Edit(string listingId, string title, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> GetOffersCount(string id, CancellationToken cancellationToken = default)
         => await this.Data.Offers.Where(x => x.ListingId == id && x.IsAccepted == false).CountAsync(cancellationToken: cancellationToken);
        

        public async Task<decimal> GetCurrentOffer(string creatorId, string listingId, CancellationToken cancellationToken = default)
        {
            var offer = await this.Data.Offers.FirstOrDefaultAsync(x =>
                x.CreatorId == creatorId && x.ListingId == listingId && x.IsAccepted == false, cancellationToken: cancellationToken);
            if (offer == null)
            {
                return 0;
            }

            return offer.Price;
        }

        //public async Task<CarAd> Find(int id, CancellationToken cancellationToken = default)
        //    => await this
        //        .All()
        //        .Include(c => c.Manufacturer)
        //        .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        //public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        //{
        //    var carAd = await this.Data.CarAds.FindAsync(id);

        //    if (carAd == null)
        //    {
        //        return false;
        //    }

        //    this.Data.CarAds.Remove(carAd);

        //    await this.Data.SaveChangesAsync(cancellationToken);

        //    return true;
        //}

        //public async Task<IEnumerable<TOutputModel>> GetCarAdListings<TOutputModel>(
        //    Specification<CarAd> carAdSpecification,
        //    Specification<Dealer> dealerSpecification,
        //    CarAdsSortOrder carAdsSortOrder,
        //    int skip = 0,
        //    int take = int.MaxValue,
        //    CancellationToken cancellationToken = default)
        //    => (await this.mapper
        //        .ProjectTo<TOutputModel>(this
        //            .GetCarAdsQuery(carAdSpecification, dealerSpecification)
        //            .Sort(carAdsSortOrder))
        //        .ToListAsync(cancellationToken))
        //        .Skip(skip)
        //        .Take(take); // EF Core bug forces me to execute paging on the client.

        //public async Task<CarAdDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default)
        //    => await this.mapper
        //        .ProjectTo<CarAdDetailsOutputModel>(this
        //            .AllAvailable()
        //            .Where(c => c.Id == id))
        //        .FirstOrDefaultAsync(cancellationToken);

        //public async Task<Category> GetCategory(
        //    int categoryId,
        //    CancellationToken cancellationToken = default)
        //    => await this
        //        .Data
        //        .Categories
        //        .FirstOrDefaultAsync(c => c.Id == categoryId, cancellationToken);

        //public async Task<Manufacturer> GetManufacturer(
        //    string manufacturer,
        //    CancellationToken cancellationToken = default)
        //    => await this
        //        .Data
        //        .Manufacturers
        //        .FirstOrDefaultAsync(m => m.Name == manufacturer, cancellationToken);

        //public async Task<IEnumerable<GetCarAdCategoryOutputModel>> GetCarAdCategories(
        //    CancellationToken cancellationToken = default)
        //{
        //    var categories = await this.mapper
        //        .ProjectTo<GetCarAdCategoryOutputModel>(this.Data.Categories)
        //        .ToDictionaryAsync(k => k.Id, cancellationToken);

        //    var carAdsPerCategory = await this.AllAvailable()
        //        .GroupBy(c => c.Category.Id)
        //        .Select(gr => new
        //        {
        //            CategoryId = gr.Key,
        //            TotalCarAds = gr.Count()
        //        })
        //        .ToListAsync(cancellationToken);

        //    carAdsPerCategory.ForEach(c => categories[c.CategoryId].TotalCarAds = c.TotalCarAds);

        //    return categories.Values;
        //}

        //public async Task<int> Total(
        //    Specification<CarAd> carAdSpecification,
        //    Specification<Dealer> dealerSpecification,
        //    CancellationToken cancellationToken = default)
        //    => await this
        //        .GetCarAdsQuery(carAdSpecification, dealerSpecification)
        //        .CountAsync(cancellationToken);

        //private IQueryable<CarAd> AllAvailable()
        //    => this
        //        .All()
        //        .Where(car => car.IsAvailable);

        //private IQueryable<CarAd> GetCarAdsQuery(
        //    Specification<CarAd> carAdSpecification,
        //    Specification<Dealer> dealerSpecification)
        //    => this
        //        .Data
        //        .Dealers
        //        .Where(dealerSpecification)
        //        .SelectMany(d => d.CarAds)
        //        .Where(carAdSpecification);

    }
}
