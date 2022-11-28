using System.Data.Common;
using exchange_rates_backend.DTOs;
using Microsoft.AspNetCore.Mvc;
using exchange_rates_backend.Models;
using exchange_rates_backend.Persistence;
using exchange_rates_backend.Services;
using Microsoft.EntityFrameworkCore;

namespace exchange_rates_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(AppDbContext context, IUsersService usersService)
        {
            _usersService = usersService;
        }

        // GET: api/Users/5
        [HttpGet("{email}")]
        public async Task<ActionResult<UserResponseDto>> GetUserEntity(string email)
        {
            var userEntity = await _usersService.FindByEmail(email);
            if (userEntity is null)
            {
                return NotFound();
            }

            return Ok(new UserResponseDto() { Email = userEntity.Email, Id = userEntity.Id });
        }


        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserResponseDto>> PostUserEntity(
            [FromBody] UserCredentialsDto userCredentialsDto)
        {
            var createdUserEntity = await _usersService.Add(new UserEntity()
                { Email = userCredentialsDto.Email, Password = userCredentialsDto.Password });
            if (createdUserEntity is null)
            {
                return BadRequest();
            }

            return StatusCode(StatusCodes.Status201Created,
                new UserResponseDto() { Id = createdUserEntity.Id, Email = createdUserEntity.Email });
        }
    }
}