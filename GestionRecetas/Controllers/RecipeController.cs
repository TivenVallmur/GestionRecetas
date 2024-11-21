using GestionRecetas.Interfaces;
using GestionRecetas.Models;
using GestionRecetas.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestionRecetas.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    [Route("Recipe")]
    public class RecipeController : ControllerBase
    {
        //private readonly IRecipeService _recipeService;
        private readonly IDatabaseRecipeService DbRecipeService;
        private readonly IApiRecipeService EdmService = RecipeFactory.GetRecipeService("Edamam");
        private readonly IApiRecipeService MdbService = RecipeFactory.GetRecipeService("TheMealdb");
        
        // Inyección de dependencias a través del constructor
        //public RecipeController(IRecipeService recipeService)
        //{
        //    _recipeService = recipeService;
        //}

        [HttpGet("GetRecipesByCountry")]
        public async Task<IActionResult> GetRecipesByCountry(string country)
        {
            var lstEdmRecipes = await EdmService.GetRecipesByCountry(country);
            var lstMdbRecipes = await MdbService.GetRecipesByCountry(country);
           
            if (lstEdmRecipes == null || lstEdmRecipes.Count == 0 || lstMdbRecipes == null || lstMdbRecipes.Count == 0)
            {
                return NotFound("No recipes found for the given country.");
            }
            
            var allRecipes = lstEdmRecipes.Union(lstMdbRecipes).ToList();

            return Ok(allRecipes);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetRecipeDetails(string id, RecipeProvider provider) // Usa string si el id es alfanumérico
        {
            Recipe details = new Recipe();
            switch (provider)
            {
                case RecipeProvider.Edamam:
                    details = await EdmService.GetRecipeById(id);
                    break;
                case RecipeProvider.TheMealDb:
                    details = await MdbService.GetRecipeById(id);
                    break;
                default:
                    break;
            }
            
            if (details == null)
            {
                return NotFound("Recipe details not found.");
            }
            return Ok(details);
        }
    }
}
