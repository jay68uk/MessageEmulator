using System.Data;

namespace Message_Emulator.App.Data;

public interface IDbConnectionFactory
{
    Task<IDbConnection> CreateConnectionAsync();
}