using GestionRecetas.Interfaces;
using GestionRecetas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestionRecetas.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    [Route("Recipe")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        // Inyección de dependencias a través del constructor
        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet("GetRecipesByCountry")]
        public async Task<IActionResult> GetRecipesByCountry(string country)
        {
            var recipes = await _recipeService.GetRecipesByCountry(country);
            if (recipes == null || recipes.Count == 0)
            {
                return NotFound("No recipes found for the given country.");
            }
            return Ok(recipes);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetRecipeDetails(string id) // Usa string si el id es alfanumérico
        {
            var details = await _recipeService.GetRecipeById(id); // Cambiado para que coincida con el servicio
            if (details == null)
            {
                return NotFound("Recipe details not found.");
            }
            return Ok(details);
        }
    }
}
