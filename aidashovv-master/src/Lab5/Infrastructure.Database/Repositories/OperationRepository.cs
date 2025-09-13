using Infrastructure.Database.Interfaces;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Entities;
using Lab5.Application.Models.ResultTypes;
using System.Data.Common;

namespace Infrastructure.Database.Repositories;

public class OperationRepository : IOperationRepository
{
    private readonly IDatabaseConnection _dbConnection;

    public OperationRepository(IDatabaseConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public OperationResult<Operation> Create(Operation operation)
    {
        using DbConnection connection = _dbConnection.GetDbConnection();
        using DbCommand command = connection.CreateCommand();

        const string sql = """
                           INSERT INTO Operations (Id, OwnerId, Name, Amount)
                           VALUES (@id, @ownerId, @name, @amount)
                           """;

        command.CommandText = sql;
        command.Parameters.Add(new Npgsql.NpgsqlParameter("@id", operation.Id));
        command.Parameters.Add(new Npgsql.NpgsqlParameter("@ownerId", operation.OwnerId));
        command.Parameters.Add(new Npgsql.NpgsqlParameter("@name", operation.Name));
        command.Parameters.Add(new Npgsql.NpgsqlParameter("@amount", operation.Amount));

        int rowsAffected = command.ExecuteNonQuery();

        if (rowsAffected <= 0)
            return new OperationResult<Operation>.FailureWithCreateOperation("Не удалось сформировать операцию.");

        return new OperationResult<Operation>.SuccessValue(operation);
    }

    public OperationResult<IReadOnlyCollection<Operation>> GetOperationHistory(Guid ownerId)
    {
        using DbConnection connection = _dbConnection.GetDbConnection();
        using DbCommand command = connection.CreateCommand();

        const string sql = """
                           SELECT Id, OwnerId, Name, Amount
                           FROM Operations
                           WHERE OwnerId = @ownerId
                           """;

        command.CommandText = sql;
        command.Parameters.Add(new Npgsql.NpgsqlParameter("@ownerId", ownerId));

        using DbDataReader reader = command.ExecuteReader();
        var operations = new List<Operation>();

        while (reader.Read())
        {
            var operation = new Operation(
                reader.GetGuid(0),
                reader.GetGuid(1),
                reader.GetString(2),
                reader.GetInt32(3));

            operations.Add(operation);
        }

        return new OperationResult<IReadOnlyCollection<Operation>>.SuccessValue(operations);
    }
}