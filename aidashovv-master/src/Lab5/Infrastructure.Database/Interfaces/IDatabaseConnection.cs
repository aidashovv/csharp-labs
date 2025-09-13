using System.Data.Common;

namespace Infrastructure.Database.Interfaces;

public interface IDatabaseConnection
{
    DbConnection GetDbConnection();
}