# Domain Driven Design ASP.NET-Microservices-App - Seller
#### ASP.NET Core Server + Angular Client

### Seller APP Idea
This is **extreamly** simple app for Listing Properties on the market, make offfers and make deal for them.

## Domain Driven Design part
**Seller.Listings** Microservice is **reworked with DDD**
**Seller.Offers** Microservice is **reworked with DDD**
**Seller.Shared.DDD**  for containing All **Domain Driven Design Common Code**

### Domain Driven Design idea in this app
#### Here My goal is simple **Clean Architecture** as it could be that easy ... so we have to Split the app on Layers 
1. Domain Layer - Entities - no data anotations, validations, custom domain exceptions, private setters, internal constuctors, public factories only for the aggregate roots
2. Application Layer - using Intefaces and Commands (All but GET) & Queries (GET) for every call from the controllers, using MediatoR, using Input and Output Models
3. Infrastructure Layer - Using Repository patern
4. Presentation Layer - using Controllers with No application logic
5. Test - App is generaly Tested with the Client, but there are some thest on Listings MS Domain Layer, Infrastructure Layer and Start Project

##### In a few words on my FIRST DDD app I just tryed to split the app and integrate as much DDD concepts as I can and have the client app to asure myself if wroks as intended so these are the flows in the app that I can see:

### What is Missing from Domain Driven Design Consepts or simply can be done better:
1. Domain - Value Objects Not used, Enumerations Not used, Events Not used, Validations only in domain layer
2. Application - Automapper is Not used 
3. Infrastructure - No DB objects
4. Test - The app is Not truly tested only few test are made
5. Offers MS Repository is too messy with a lot of logic. On Listing MS the tree repositories there are a lot cleaner.



## App content
##### Clent Url http://localhost:4200
- Clent App Angular
- Server Apps ASP.NET 3.1 - **9 Microservices**
	1. Seller.Admin - MVC only for Admin http://localhost:5013
	2. Seller.Identity - Api with DB - Entity Asp.Net.USer
	3. Seller.Listings - Api with DB - Entities - Seller : User, Lising, Deals and Messages from Masstransit
	4. Seller.Messages - Api with DB - Entity  Message
	5. Seller.Offers - Api with DB - Entity Offer
	6. Seller.Listings.Gateway - Api Gateway
	7. Seller.Shared - Library

## App functionality

#### Not Logged User can do
1. **/** - See Landing page
2. **Login** - *on Post* direct Call login User
3. **Register** - *on Post* Multy Call to IdentityMS to Register User and ListingsMS to Create Seller : User **First Registered user is Admin**

#### Logged User can do
1. **See All Lisings** - *on Get* Direct Call to Listing MS, Search - Client implementation
2. **See Mini Lisings** - *on Get* Direct Call to Listing MS, Search - Client implementation
3. **Add Listing** - *on Post* Direct Call to Listing MS and**Using Messaging** to send message to NotificationsMS Using SingleR
		notify the Client and all Logged User about that new listing is published.
4. **Lising Deatails** - *on Get* See details Milty Call *from Client to LisingMS* and  *from Client OffersMS* to get offersCount
		
	-  If User **is Owner** of listing
		
	1.  **See all offers** - *on Get* Call to **Lising.Gateway** ot agregete data from OffersMS And LisingMS
				**Accept**	*on Post* direct call To LisingsMS to crete Deal and set Lising.IsDeal to true and
				**Using Messaging** call to OfferMS to set this IsAccepted to true to all other offer IsDeleted to True
				
	2.  **Edit Lising** - *on Get* - Direct Call to LisingMS, *on Post* Direct Call edit Lising and,
			**Using Messaging** if Title is changed to *Consumer - OffersMS* (*offer title = listing title* if there are offers change thеir title)
			
	3.  **Delete Lising** - *on Post* Direct Call edit Lising and, **Using Messaging** to set Offers.IsDeleted all associated with this listing 
			to true - soft delete
			
	- If User **is not Owner** of listing - **Add Offer** - *on Post* Direct Call to OffersMS
5. **Mine Offers** - *on Get*  Call To **Lisings.Gateway** to aggregate data from  *LisingMS and OffersMS*
		- **Deatails** - see listing details;
		- **Delete** - *on Post* Set IsDeleted to true
6. **Mine Deals** - *on Get*  Call To **Lisings.Gateway** to aggregate data from  *LisingMS Buy Deals And Sale Deals Service*
		and see all Bought Properties and all Sold Properties
7. **Contact Us** - *on Post* irect call to Seller.Messages send message to site administrator 
8. **Logout** - Clent delete token from Localstorage 
	
#### Admin can do
1. Can login in **AdminMS** *on get* Direct call to MessageMS see all sent messages from users and archive them on *on Post* direct call.

