using exchange_rates_backend.Models;

namespace exchange_rates_backend.Services;

public interface IUsersService
{
    public Task<UserEntity?> Add(UserEntity userEntity);
    public Task<UserEntity?> FindByEmail(string email);
}