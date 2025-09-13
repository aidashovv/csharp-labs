using Infrastructure.Database.Interfaces;
using System.Data.Common;

namespace Infrastructure.Database.Migrations;

public class Initial
{
    public static void Initialize(IDatabaseConnection databaseConnection)
    {
        using DbConnection connection = databaseConnection.GetDbConnection();
        using DbCommand command = connection.CreateCommand();

        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Users (
                Id UUID PRIMARY KEY,
                Name TEXT NOT NULL
            );";
        command.ExecuteNonQuery();

        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS BankAccounts (
                Id UUID PRIMARY KEY,
                OwnerId UUID NOT NULL REFERENCES Users(Id) ON DELETE CASCADE,
                Pin TEXT NOT NULL,
                Balance INT NOT NULL CHECK (Balance >= 0)
            );";
        command.ExecuteNonQuery();

        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Operations (
                Id UUID PRIMARY KEY,
                OwnerId UUID NOT NULL REFERENCES BankAccounts(Id),
                Name TEXT NOT NULL,
                Amount INT NOT NULL
            );";
        command.ExecuteNonQuery();
    }
}