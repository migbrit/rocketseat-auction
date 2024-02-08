using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Contracts;

public interface IUserRepository
{
    User GetUserByEmail(string email);
    bool UserExists(string email);
}
