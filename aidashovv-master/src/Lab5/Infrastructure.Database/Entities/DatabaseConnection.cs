using Infrastructure.Database.Interfaces;
using Npgsql;
using System.Data.Common;

namespace Infrastructure.Database.Entities;

public class DatabaseConnection : IDatabaseConnection
{
    private readonly string _dbConnectionString;

    public DatabaseConnection(string dbConnectionString)
    {
        _dbConnectionString = dbConnectionString;
    }

    public DbConnection GetDbConnection()
    {
        var connection = new NpgsqlConnection(_dbConnectionString);
        connection.Open();
        return connection;
    }
}