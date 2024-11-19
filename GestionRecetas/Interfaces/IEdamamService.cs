using GestionRecetas.Models;

namespace GestionRecetas.Interfaces
{
    public interface IEdamamService
    {
        Task<List<Recipe>> GetRecipesByCountry(string country);
        Task<Recipe> GetRecipeDetails(string recipeId);
    }
}
