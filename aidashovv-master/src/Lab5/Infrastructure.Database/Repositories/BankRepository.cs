using Infrastructure.Database.Interfaces;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Entities;
using Lab5.Application.Models.ResultTypes;
using System.Data.Common;

namespace Infrastructure.Database.Repositories;

public class BankRepository : IBankRepository
{
    private readonly IDatabaseConnection _dbConnection;

    public BankRepository(IDatabaseConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public BankAccountResult<BankAccount> Create(BankAccount bankAccount)
    {
        using DbConnection connection = _dbConnection.GetDbConnection();
        using DbCommand command = connection.CreateCommand();

        const string sql = """
                           INSERT INTO BankAccounts (Id, OwnerId, Pin, Balance)
                           VALUES (@id, @ownerId, @pin, @balance)
                           """;

        command.CommandText = sql;
        command.Parameters.Add(new Npgsql.NpgsqlParameter("@id", bankAccount.Id));
        command.Parameters.Add(new Npgsql.NpgsqlParameter("@ownerId", bankAccount.OwnerId));
        command.Parameters.Add(new Npgsql.NpgsqlParameter("@pin", bankAccount.Pin));
        command.Parameters.Add(new Npgsql.NpgsqlParameter("@balance", bankAccount.Balance));

        int rowsAffected = command.ExecuteNonQuery();

        if (rowsAffected <= 0)
            return new BankAccountResult<BankAccount>.FailureWithCreateAccount("Не удалось создать банковский счет.");

        return new BankAccountResult<BankAccount>.SuccessValue(bankAccount);
    }

    public BankAccountResult<BankAccount> GetById(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Недопустимый идентификатор счета.", nameof(id));

        using DbConnection connection = _dbConnection.GetDbConnection();
        using DbCommand command = connection.CreateCommand();

        const string sql = """
                           SELECT Id, OwnerId, Pin, Balance
                           FROM BankAccounts
                           WHERE Id = @id
                           """;

        command.CommandText = sql;
        command.Parameters.Add(new Npgsql.NpgsqlParameter("@id", id));

        using DbDataReader reader = command.ExecuteReader();

        if (!reader.HasRows)
            return new BankAccountResult<BankAccount>.FailureWithFindAccount("Не удалось найти банковский счет.");

        reader.Read();

        var bankAccount = new BankAccount(
            reader.GetGuid(0),
            reader.GetGuid(1),
            reader.GetString(2),
            reader.GetInt32(3));

        return new BankAccountResult<BankAccount>.SuccessValue(bankAccount);
    }

    public BankAccountResult<BankAccount> Update(BankAccount bankAccount)
    {
        using DbConnection connection = _dbConnection.GetDbConnection();
        using DbCommand command = connection.CreateCommand();

        const string sql = """
                           UPDATE BankAccounts
                           SET Balance = @balance
                           WHERE Id = @id
                           """;

        command.CommandText = sql;
        command.Parameters.Add(new Npgsql.NpgsqlParameter("@balance", bankAccount.Balance));
        command.Parameters.Add(new Npgsql.NpgsqlParameter("@id", bankAccount.Id));

        int rowsAffected = command.ExecuteNonQuery();

        if (rowsAffected <= 0)
        {
            return new BankAccountResult<BankAccount>.FailureWithUpdate("Не удалось обновить банковский счет.");
        }

        return new BankAccountResult<BankAccount>.SuccessValue(bankAccount);
    }
}