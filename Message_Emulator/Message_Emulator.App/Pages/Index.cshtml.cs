using Message_Emulator.App.Models;
using Message_Emulator.App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Message_Emulator.App.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ModelService _service;

    public bool ModelCreated { get; set; } = false;

    [BindProperty]
    public JsonSchemaInputModel JsonSchemaInput { get; set; }
    
    public IndexModel(ILogger<IndexModel> logger, ModelService service)
    {
        _logger = logger;
        _service = service;
    }

    public IEnumerable<JsonSchemaInputModel> ExistingModels { get; set; }

    public async Task OnGetAsync()
    {
        ExistingModels = await _service.GetExistingModelsAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        ModelCreated = false;
        
        if (!ModelState.IsValid)
        {
            return Page(); // Stay on the same page if the model is invalid
        }

        ModelCreated= await _service.CreateJsonSchemaModel(JsonSchemaInput);

        return RedirectToPage(); // Redirect to the same or a different page as needed
    }
}