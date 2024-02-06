using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Http.Requests;

namespace RocketseatAuction.API.Controllers;
public class OfferController : RocketseatAuctionBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    public IActionResult CreateOffer([FromRoute] int itemId, [FromBody] RequestCreateOffer request)
    {
        return Created();
    }
}
