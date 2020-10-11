﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Seller.Listing.Gateway.Models.Deals;
using Seller.Listing.Gateway.Models.Offers;
using Seller.Listing.Gateway.Services.Deal;
using Seller.Listing.Gateway.Services.Listing;
using Seller.Listing.Gateway.Services.Offer;
using Seller.Shared.Controllers;

namespace Seller.Listing.Gateway.Controllers
{
    public class ListingController : ApiController
    {
        private readonly IListingService listingService;
        private readonly IOfferService offerService;
        private readonly IDealService dealService;

        public ListingController(IListingService listingService, IOfferService offerService, IDealService dealService)
        {
            this.listingService = listingService;
            this.offerService = offerService;
            this.dealService = dealService;
        }



        [HttpGet]
        [Authorize]
        [Route("OffersAll/{id}")]
        public async Task<List<OfferResponceModelWithName>> OffersAll(string id)
        {
            var offers = await offerService.All(id);
            var listing = await listingService.GetTitleAndSellerName(id);
            
            var result = new List<OfferResponceModelWithName>();

            foreach (var offerResponceModel in offers)
            {
                result.Add(new OfferResponceModelWithName
                {
                    Created = offerResponceModel.Created,
                    CreatorId = offerResponceModel.CreatorId,
                    Id = offerResponceModel.Id,
                    ListingId = offerResponceModel.ListingId,
                    Price = offerResponceModel.Price,
                    SellerName = listing.SellerName,
                    BuyerName = offerResponceModel.CreatorName,
                    Title = listing.Title,
                });
            }

            return result;
        }

        [HttpPost]
        [Authorize]
        [Route(nameof(Deal))]
        public async Task<bool> Deal(OfferAcceptRequestModel model)
        {
            var deal = new DealCreateRequestModel
            {
                Title = model.Title,
                Price = model.Price,
                ListingId = model.ListingId,
                OfferId = model.Id,
                SellerId = model.CreatorId,
                BuyerId = model.BuyerId
            };
            return await dealService.Create(deal);
        }
    }
}
