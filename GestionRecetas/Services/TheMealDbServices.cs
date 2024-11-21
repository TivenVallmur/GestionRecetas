using GestionRecetas.Interfaces;
using GestionRecetas.Models;

namespace GestionRecetas.Services
{
    public class TheMealDbServices : IApiRecipeService
    {
        public async Task<Recipe> GetRecipeById(string recipeId)
        {
            Recipe recipe = new Recipe();

            return recipe;
        }

        public async Task<List<Recipe>> GetRecipesByCountry(string country)
        {
            List<Recipe> lstRecipe = new List<Recipe>();
            return lstRecipe;
        }
    }
}
