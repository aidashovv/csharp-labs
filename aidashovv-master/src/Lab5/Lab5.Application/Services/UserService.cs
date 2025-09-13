using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Services;
using Lab5.Application.Models.Entities;
using Lab5.Application.Models.ResultTypes;

namespace Lab5.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public UserResult<User> Create(User user)
    {
        return _userRepository.Create(user);
    }

    public UserResult<User> GetById(Guid id)
    {
        return _userRepository.GetById(id);
    }

    public UserResult<IReadOnlyList<User>> GetAllUsers()
    {
        return _userRepository.GetAllUsers();
    }
}