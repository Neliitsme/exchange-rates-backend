using exchange_rates_backend.Models;
using exchange_rates_backend.Persistence;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;

namespace exchange_rates_backend.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<UserEntity> Add(UserEntity userEntity)
    {
        _context.Add(userEntity);
        return userEntity;
    }

    public async Task<UserEntity?> FindByEmail(string email)
    {
        return await _context.UserEntities.FirstOrDefaultAsync(ue => ue.Email.Equals(email));
    }
}