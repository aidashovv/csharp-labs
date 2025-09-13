using Lab5.Application.Models.Entities;
using Lab5.Application.Models.ResultTypes;

namespace Lab5.Application.Abstractions.Repositories;

public interface IUserRepository
{
    UserResult<User> Create(User user);

    UserResult<User> GetById(Guid id);

    UserResult<IReadOnlyList<User>> GetAllUsers();
}