using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;

namespace RocketseatAuction.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuctionController : ControllerBase
{
    private readonly GetCurrentAuctionUseCase _getCurrentAuctionUseCase;
    public AuctionController(GetCurrentAuctionUseCase getCurrentAuctionUseCase)
    {
        _getCurrentAuctionUseCase = getCurrentAuctionUseCase;
    }

    [HttpGet]
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentAction()
    {
        var result = _getCurrentAuctionUseCase.Execute();

        if(result is null)
            return NoContent();

        return Ok(result);
    }
}

