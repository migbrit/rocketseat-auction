using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.UseCases.Users.GetUser;

public class GetUserUseCase
{
    private readonly IHttpContextAccessor _httpContext;
    private readonly IUserRepository _userRepository;
    public GetUserUseCase(IHttpContextAccessor httpContext, IUserRepository userRepository)
    {
        _httpContext = httpContext;
        _userRepository = userRepository;
    }
    public User Execute()
    {
        var token = TokenOnRequest();

        var email = FromBase64String(token);

        return _userRepository.GetUserByEmail(email);
    }

    private string TokenOnRequest()
    {
        var authentication = _httpContext.HttpContext!.Request.Headers.Authorization.ToString();

        return authentication.Replace("Bearer", "").Trim();
    }

    private string FromBase64String(string base64)
    {
        var isValidBase64 = IsValidBase64(base64);

        if (isValidBase64)
        {
            var data = Convert.FromBase64String(base64);
            return System.Text.Encoding.UTF8.GetString(data);
        }
        return "";
    }

    private bool IsValidBase64(string base64)
    {
        try
        {
            Convert.FromBase64String(base64);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Invalid Base64");
            return false;
        }
    }
}
