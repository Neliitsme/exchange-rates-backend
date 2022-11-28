using System.IdentityModel.Tokens.Jwt;
using exchange_rates_backend.DTOs;
using exchange_rates_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace exchange_rates_backend.Controllers;

[Route("api/[controller]/signin")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IUsersService _usersService;

    public AuthController(IAuthService authService, IUsersService usersService)
    {
        _authService = authService;
        _usersService = usersService;
    }

    [HttpPost]
    public async Task<ActionResult<AccessTokenDto>> SignIn([FromBody] UserCredentialsDto
        userCredentialsDto)
    {
        var userEntity = await _usersService.FindByEmail(userCredentialsDto.Email);
        if (userEntity is null)
        {
            return Unauthorized();
        }

        var token = await _authService.VerifyUser(userCredentialsDto, userEntity);

        return token is null
            ? Unauthorized()
            : Ok(new AccessTokenDto()
                { AccessToken = new JwtSecurityTokenHandler().WriteToken(token), ValidTo = token.ValidTo }
            );
    }
}