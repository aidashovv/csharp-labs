using Lab5.Application.Models.Entities;
using Lab5.Application.Models.ResultTypes;

namespace Lab5.Application.Contracts.Services;

public interface IUserService
{
    UserResult<User> Create(User user);

    UserResult<User> GetById(Guid id);

    UserResult<IReadOnlyList<User>> GetAllUsers();
}