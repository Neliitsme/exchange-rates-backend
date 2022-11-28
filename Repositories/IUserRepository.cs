using exchange_rates_backend.Models;

namespace exchange_rates_backend.Repositories;

public interface IUserRepository
{
    public Task<UserEntity> Add(UserEntity userEntity);
    public Task<UserEntity?> FindByEmail(string email);
}