using Dapper;
using Message_Emulator.App.Data;
using Message_Emulator.App.Models;

namespace Message_Emulator.App.Services;

public sealed class ModelService
{
    private readonly ILogger<ModelService> _logger;
    private readonly IDbConnectionFactory _connectionFactory;

    public ModelService(ILogger<ModelService> logger, IDbConnectionFactory connectionFactory)
    {
        _logger = logger;
        _connectionFactory = connectionFactory;
    }

    internal async Task<bool> CreateJsonSchemaModel(JsonSchemaInputModel model)
    {
        var connection = await _connectionFactory.CreateConnectionAsync();
        
        // var bookExists = await GetByIsbnAsync(book.Isbn);
        // if (bookExists is not null)
        // {
        //     return false;
        // }
        const string sql = "INSERT INTO message_models (title, description, json_schema) VALUES (@Title, @Description, @JsonSchema)";
        var result = await connection.ExecuteAsync(sql, model);

        return result > 0;
    }

    internal async Task<IEnumerable<JsonSchemaInputModel>> GetExistingModelsAsync()
    {
        var connection = await _connectionFactory.CreateConnectionAsync();
        var result =
            await connection.QueryAsync<JsonSchemaInputModel>(
                "SELECT title, description, json_schema FROM message_models ORDER BY title");

        return result;
    }
}