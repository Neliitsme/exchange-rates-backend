using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using exchange_rates_backend.DTOs;
using exchange_rates_backend.Models;

namespace exchange_rates_backend.Services;

public interface IAuthService
{
    public Task<JwtSecurityToken?> VerifyUser(UserCredentialsDto userCredentialsDto, UserEntity userEntity);
    public JwtSecurityToken GenerateToken(IEnumerable<Claim> authClaims);
}