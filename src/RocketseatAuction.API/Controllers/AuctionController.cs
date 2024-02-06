using Microsoft.AspNetCore.Mvc;
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
    public IActionResult GetCurrentAction()
    {
        var result = _getCurrentAuctionUseCase.Execute();

        return Ok(result);
    }
}

