using System.Collections.Generic;
using System.Collections.Immutable;
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
                        x.IsAccepted == false &&
                        x.IsDeleted == false,
                cancellationToken: cancellationToken).Result;

            if (offer != null)
            {
                offer.UpdatePrice(price);
                await this.Save(offer, cancellationToken);
                return new AddOfferOutputModel(
                    offer.Id, offer.ListingId, offer.Price, offer.Created, offer.CreatorId, offer.IsAccepted, offer.Title, offer.CreatorName);
            }

            return new AddOfferOutputModel();
        }

        public async Task<IReadOnlyList<AllOfferOutputModel>> All(string listingId, CancellationToken cancellationToken = default)
            => await Data
                .Offers
                .Where(x => x.ListingId == listingId && x.IsAccepted == false && x.IsDeleted == false)
                .OrderByDescending(x => x.Created)
                .Select(x => new AllOfferOutputModel(x.Id, x.ListingId, x.Price, x.Created, x.CreatorId, x.IsAccepted, x.Title, x.CreatorName))
                .ToListAsync(cancellationToken: cancellationToken);

        public async Task<IReadOnlyList<MineOfferOutputModel>> Mine(string userId, CancellationToken cancellationToken = default)
        => await Data
               .Offers
               .Where(x => x.CreatorId == userId && x.IsAccepted == false && x.IsDeleted == false)
               .OrderByDescending(x => x.Created)
               .Select(x => new MineOfferOutputModel(x.Id, x.ListingId, x.Price, x.Created, x.CreatorId, x.IsAccepted, x.Title, x.CreatorName))
               .ToListAsync(cancellationToken: cancellationToken);

        public async Task<bool> Accept(string id, CancellationToken cancellationToken = default)
        {
            var offer = await Data.Offers.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);
            if (offer == null)
            {
                return false;
            }
            offer.UpdateIsAccepted();
            var offers = await Data.Offers.Where(x => x.ListingId == offer.ListingId && x.IsAccepted == false).ToListAsync(cancellationToken: cancellationToken);
            foreach (var offer1 in offers)
            {
                if (offer1.Id == offer.Id) continue;
                offer1.UpdateIsDeleted();
            }

            Data.Offers.Update(offer);
            Data.Offers.UpdateRange(offers);

            var result = await Data.SaveChangesAsync(cancellationToken);
            return result != 0;
        }

        public async Task<bool> Delete(string listingId, CancellationToken cancellationToken = default)
        {
            var offer = await Data.Offers
                .Where(x => x.ListingId == listingId && x.IsAccepted == false)
                .ToListAsync(cancellationToken: cancellationToken);

            offer.ForEach(x => x.UpdateIsDeleted());

            Data.Offers.UpdateRange(offer);

            var result = await Data.SaveChangesAsync(cancellationToken);

            return result != 0;
        }

        public async Task<bool> DeleteOffer(string id, CancellationToken cancellationToken = default)
        {
            var offer = await this.Data.Offers.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);
            if (offer == null)
            {
                return false;
            }
            offer.UpdateIsDeleted();
            return await Data.SaveChangesAsync(cancellationToken) != 0;
        }

        public async Task<bool> Edit(string listingId, string title, CancellationToken cancellationToken = default)
        {
            var offer = await Data.Offers.Where(x =>
                        x.ListingId == listingId &&
                        x.IsAccepted == false &&
                        x.IsDeleted == false).ToListAsync(cancellationToken: cancellationToken);

            offer.ForEach(x => x.UpdateTittle(title));

            Data.Offers.UpdateRange(offer);

            var result = await Data.SaveChangesAsync(cancellationToken);

            return result != 0;
        }

        public async Task<int> GetOffersCount(string id, CancellationToken cancellationToken = default)
         => await this.Data.Offers.Where(x => x.ListingId == id && x.IsAccepted == false && x.IsDeleted == false).CountAsync(cancellationToken: cancellationToken);


        public async Task<decimal> GetCurrentOffer(string creatorId, string listingId, CancellationToken cancellationToken = default)
        {
            var offer = await this.Data.Offers.FirstOrDefaultAsync(x =>
                x.CreatorId == creatorId && x.ListingId == listingId && x.IsAccepted == false && x.IsDeleted == false, cancellationToken: cancellationToken);
            if (offer == null)
            {
                return 0;
            }

            return offer.Price;
        }

    }
}
