using exchange_rates_backend.Models;
using exchange_rates_backend.Persistence;
using exchange_rates_backend.Repositories;

namespace exchange_rates_backend.Services;

public class UsersService : IUsersService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UsersService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UserEntity?> Add(UserEntity userEntity)
    {
        if (await _userRepository.FindByEmail(userEntity.Email) != null)
        {
            return null;
        }

        userEntity.Password = BCrypt.Net.BCrypt.HashPassword(userEntity.Password, workFactor: 8);
        var createdUserEntity = await _userRepository.Add(userEntity);
        await _unitOfWork.CompleteAsync();
        return createdUserEntity;
    }

    public async Task<UserEntity?> FindByEmail(string email)
    {
        return await _userRepository.FindByEmail(email);
    }
}