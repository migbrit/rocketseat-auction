using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories;

public class UserRepository : IUserRepository
{
    private readonly RocketseatAuctionDbContext _dbContext;
    public UserRepository(RocketseatAuctionDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public User GetUserByEmail(string email)
    {
        return _dbContext.Users.First(user => user.Email == email);
    }

    public bool UserExists(string email)
    {
        return _dbContext.Users.Any(user => user.Email.Equals(email));
    }
}
