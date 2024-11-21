using GestionRecetas.Models;

namespace GestionRecetas.Interfaces
{
    public interface IApiRecipeService
    {
        Task<Recipe> GetRecipeById(string recipeId); // Obtener una receta por ID
        Task<List<Recipe>> GetRecipesByCountry(string country); // Obtener recetas por país
    }
}
