namespace Message_Emulator.App.Models;

public sealed class JsonSchemaInputModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string JsonSchema { get; set; }
    public bool IsEdit { get; set; }
}