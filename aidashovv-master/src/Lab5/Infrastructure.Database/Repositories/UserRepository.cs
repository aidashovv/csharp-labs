using Infrastructure.Database.Interfaces;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Entities;
using Lab5.Application.Models.ResultTypes;
using System.Data.Common;

namespace Infrastructure.Database.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDatabaseConnection _dbConnection;

    public UserRepository(IDatabaseConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public UserResult<User> Create(User user)
    {
        using DbConnection connection = _dbConnection.GetDbConnection();
        using DbCommand command = connection.CreateCommand();

        const string sql = """
                           INSERT INTO Users (Id, Name)
                           VALUES (@id, @name)
                           """;

        command.CommandText = sql;
        command.Parameters.Add(new Npgsql.NpgsqlParameter("@id", user.Id));
        command.Parameters.Add(new Npgsql.NpgsqlParameter("@name", user.Name));

        int rowsAffected = command.ExecuteNonQuery();

        if (rowsAffected <= 0)
        {
            return new UserResult<User>.Failure("Не удалось создать пользователя.");
        }

        return new UserResult<User>.SuccessValue(user);
    }

    public UserResult<User> GetById(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Недопустимый идентификатор пользователя.", nameof(id));

        using DbConnection connection = _dbConnection.GetDbConnection();
        using DbCommand command = connection.CreateCommand();

        const string sql = """
                           SELECT Id, Name
                           FROM Users
                           WHERE Id = @id
                           """;

        command.CommandText = sql;
        command.Parameters.Add(new Npgsql.NpgsqlParameter("@id", id));

        using DbDataReader reader = command.ExecuteReader();

        if (!reader.HasRows)
            return new UserResult<User>.Failure("Не удалось найти пользователя.");

        reader.Read();

        var user = new User(
            reader.GetGuid(0),
            reader.GetString(1));

        return new UserResult<User>.SuccessValue(user);
    }

    public UserResult<IReadOnlyList<User>> GetAllUsers()
    {
        using DbConnection connection = _dbConnection.GetDbConnection();
        using DbCommand command = connection.CreateCommand();

        const string sql = """
                           SELECT Id, Name
                           FROM Users
                           """;

        command.CommandText = sql;

        using DbDataReader reader = command.ExecuteReader();

        if (!reader.HasRows)
            return new UserResult<IReadOnlyList<User>>.Failure("Не удалось найти пользователей.");

        var users = new List<User>();

        while (reader.Read())
        {
            var user = new User(
                reader.GetGuid(0),
                reader.GetString(1));

            users.Add(user);
        }

        return new UserResult<IReadOnlyList<User>>.SuccessValue(users);
    }
}