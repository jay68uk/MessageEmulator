using Dapper;

namespace Message_Emulator.App.Data;

public class DatabaseInitialiser
{
    private readonly IDbConnectionFactory _connectionFactory;

    public DatabaseInitialiser(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task InitialiseAsync()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        
        const string sql = "CREATE TABLE IF NOT EXISTS message_models (title TEXT PRIMARY KEY, description TEXT, json_schema TEXT)";
        await connection.ExecuteAsync(sql);
        
    }
}