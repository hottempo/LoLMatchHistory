using LoLMatchHistory.Infrastructure;
using LoLMatchHistory.Infrastructure.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace LoLMatchHistory.API.Auth;

public class BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
    ILoggerFactory logger,
    UrlEncoder encoder,
    LoLMatchHistoryContext dbContext) : AuthenticationHandler<AuthenticationSchemeOptions>(options, logger, encoder)
{
    private readonly LoLMatchHistoryContext _dbContext = dbContext;

    private bool IsPublicEndpoint()
        => Context.GetEndpoint()?.Metadata.OfType<AllowAnonymousAttribute>().Any() is null or true;

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.ContainsKey("Authorization"))
        {
            return AuthenticateResult.Fail("Unauthorized");
        }

        string? authorizationHeader = Request.Headers.Authorization;
        if (string.IsNullOrEmpty(authorizationHeader))
        {
            return AuthenticateResult.Fail("Unauthorized");
        }

        if (!authorizationHeader.StartsWith("basic ", StringComparison.OrdinalIgnoreCase))
        {
            return AuthenticateResult.Fail("Unauthorized");
        }

        string token = authorizationHeader[6..];
        string credentialsString = Encoding.UTF8.GetString(Convert.FromBase64String(token));

        var credentials = credentialsString.Split(":");
        if (credentials?.Length != 2)
        {
            return AuthenticateResult.Fail("Unauthorized");
        }

        string username = credentials[0];
        string password = credentials[1];

        // TODO Here may be dragons!!! We need to hash the passwords.
        User? user = _dbContext.Users
            .SingleOrDefault(u => u.Username.Equals(username) && u.Password.Equals(password));
        if (user == null)
        {
            return AuthenticateResult.Fail("Authentication failed");
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.Sid, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, username)
        };
        var identity = new ClaimsIdentity(claims, "Basic");
        var claimsPrincipal = new ClaimsPrincipal(identity);
        return AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name));
    }

}
