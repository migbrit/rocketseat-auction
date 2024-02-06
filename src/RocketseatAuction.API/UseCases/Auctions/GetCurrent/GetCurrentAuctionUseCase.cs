using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Repositories;

namespace RocketseatAuction.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    private readonly RocketseatAuctionDbContext _dbContext;
    public GetCurrentAuctionUseCase(RocketseatAuctionDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Auction? Execute()
    {
        var today = DateTime.Now;

        return _dbContext
            .Auctions
            .Include(auction => auction.Items)
            .FirstOrDefault(a => today >= a.Starts && today <= a.Ends);
    }
}
