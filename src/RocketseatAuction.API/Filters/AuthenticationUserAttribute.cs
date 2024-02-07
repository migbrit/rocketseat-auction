using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RocketseatAuction.API.Repositories;

namespace RocketseatAuction.API.Filters;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    private readonly RocketseatAuctionDbContext _dbContext;
    public AuthenticationUserAttribute(RocketseatAuctionDbContext dbContext)
    {
        _dbContext = dbContext; 
    }
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            string token = TokenOnRequest(context.HttpContext);

            string decryptedEmail = FromBase64String(token);

            bool exist = _dbContext.Users.Any(user => user.Email.Equals(decryptedEmail));

            if (!exist)
                context.Result = new UnauthorizedObjectResult("Email is not valid");
        }
        catch(Exception ex)
        {
            context.Result = new UnauthorizedObjectResult(ex.Message);
        }
        
    }

    private string TokenOnRequest(HttpContext context)
    {
        var authentication = context.Request.Headers.Authorization.ToString();

        if(String.IsNullOrEmpty(authentication))
        {
            throw new Exception("Token is missing");
        }

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
        catch(Exception e)
        {
            Console.WriteLine("Invalid Base64");
            return false;
        }
    }
}
