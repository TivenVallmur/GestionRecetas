using Microsoft.AspNetCore.Mvc;
using GestionRecetas.Interfaces;
using GestionRecetas.Services;

[ApiController]
[Route("Edamam")]
public class EdamamController : ControllerBase
{
    private readonly IEdamamService _edamamService;

    public EdamamController(IEdamamService edamamService)
    {
        _edamamService = edamamService;
    }

    [HttpGet("GetRecipesByCountry")]
    public async Task<IActionResult> GetRecipesByCountry(string country)
    {
        var recipes = await _edamamService.GetRecipesByCountry(country);
        return Ok(recipes);
    }

    [HttpGet("GetRecipeDetails")]
    public async Task<IActionResult> GetRecipeDetails(string recipeId)
    {
        var recipe = await _edamamService.GetRecipeDetails(recipeId);
        if (recipe == null)
        {
            return NotFound();
        }
        return Ok(recipe);
    }
}
