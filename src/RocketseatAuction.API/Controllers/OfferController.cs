using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Filters;
using RocketseatAuction.API.Http.Requests;
using RocketseatAuction.API.UseCases.Offers.CreateOffer;

namespace RocketseatAuction.API.Controllers;

[ServiceFilter(typeof(AuthenticationUserAttribute))]
public class OfferController : RocketseatAuctionBaseController
{
    private readonly CreateOfferUseCase _useCase;
    public OfferController(CreateOfferUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPost]
    [Route("{itemId}")]
    public IActionResult CreateOffer([FromRoute] int itemId, [FromBody] RequestCreateOffer request)
    {
        int id = _useCase.Execute(itemId, request);
        return Created(string.Empty, id);
    }
}
