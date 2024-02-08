using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Http.Requests;
using RocketseatAuction.API.UseCases.Users.GetUser;

namespace RocketseatAuction.API.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase
{
    private readonly IGetUserUseCase _getUserUseCase;
    private readonly IOfferRepository _offerRepository;
    public CreateOfferUseCase(IGetUserUseCase getUserUseCase, IOfferRepository offerRepository)
    {
        _getUserUseCase = getUserUseCase;
        _offerRepository = offerRepository;
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

        _offerRepository.Add(offer);

        return offer.Id;
    }
}
