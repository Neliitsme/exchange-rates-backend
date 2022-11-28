using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using exchange_rates_backend.DTOs;
using exchange_rates_backend.Models;
using Microsoft.IdentityModel.Tokens;

namespace exchange_rates_backend.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<JwtSecurityToken?> VerifyUser(UserCredentialsDto userCredentialsDto, UserEntity userEntity)
    {
        if (!BCrypt.Net.BCrypt.Verify(userCredentialsDto.Password, userEntity.Password))
        {
            return null;
        }

        var authClaims = new List<Claim>
        {
            new Claim("email", userEntity.Email),
            new Claim("id", userEntity.Id.ToString())
        };
        var token = GenerateToken(authClaims);
        return token;
    }

    public JwtSecurityToken GenerateToken(IEnumerable<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:Issuer"],
            audience: _configuration["JWT:Audience"],
            expires: DateTime.Now.AddHours(1),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return token;
    }
}