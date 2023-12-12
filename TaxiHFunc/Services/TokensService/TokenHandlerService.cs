using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaxiHDataTransferObjects.DTOs.UserRelated;

namespace TaxiHFunc.Services.TokensService;
public class TokenHandlerService : ITokenHandlerService
{
    private readonly JWTSettings _jwtSettings;
    public TokenHandlerService(IOptions<JWTSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }
    public async Task<string> CreateTokenAsync(LoginDTO userCreds)
    {
        /* add fetching data from users to make token more complicated! */

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var claims = new List<Claim>();
        claims.Add(new Claim(ClaimTypes.GivenName, userCreds.Username));
        claims.Add(new Claim(ClaimTypes.Rsa, userCreds.Password));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            _jwtSettings.Issuer,
            _jwtSettings.Audience,
            claims,
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: credentials
            );
        return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));

    }
}
