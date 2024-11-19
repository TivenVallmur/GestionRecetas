using GestionRecetas.Models;

namespace GestionRecetas.Interfaces
{
    public interface IRecipeService
    {
        Task<List<Recipe>> GetAllRecipes(); // Obtener todas las recetas
        Task<Recipe> GetRecipeById(string recipeId); // Obtener una receta por ID
        Task<List<Recipe>> GetRecipesByCountry(string country); // Obtener recetas por país
        Task AddRecipe(Recipe recipe); // Añadir una nueva receta
        Task UpdateRecipe(Recipe recipe); // Actualizar una receta existente
        Task DeleteRecipe(string recipeId); // Eliminar una receta
    }
}
