using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Http.Requests;
using RocketseatAuction.API.Repositories;
using RocketseatAuction.API.UseCases.Users.GetUser;

namespace RocketseatAuction.API.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase
{
    private readonly RocketseatAuctionDbContext _dbContext;
    private readonly GetUserUseCase _getUserUseCase;
    public CreateOfferUseCase(RocketseatAuctionDbContext dbContext, GetUserUseCase getUserUseCase)
    {
        _dbContext = dbContext;
        _getUserUseCase = getUserUseCase;
    }

    public int Execute(int itemId, RequestCreateOffer request)
    {
        var offer = new Offer
        {
            ItemId = itemId,
            Price = request.Price,
            UserId = _getUserUseCase.Execute().Id,
            CreatedOn = DateTime.Now,
        };

        _dbContext.Offers.Add(offer);

        _dbContext.SaveChangesAsync();

        return offer.Id;
    }
}
