using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Filters;
using RocketseatAuction.API.Http.Requests;
using RocketseatAuction.API.UseCases.Offers.CreateOffer;

namespace RocketseatAuction.API.Controllers;

[ServiceFilter(typeof(AuthenticationUserAttribute))]
public class OfferController : RocketseatAuctionBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    
    public IActionResult CreateOffer([FromRoute] int itemId,
        [FromBody] RequestCreateOffer request,
        [FromServices] CreateOfferUseCase useCase)
    {
        int id = useCase.Execute(itemId, request);
        return Created(string.Empty, id);
    }
}
