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
    public Auction Execute()
    {
        return _dbContext.Auctions.First();
    }
}
