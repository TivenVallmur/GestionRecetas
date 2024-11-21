using GestionRecetas.Models;

namespace GestionRecetas.Interfaces
{    
    public interface IDatabaseRecipeService
    {
        Task<Recipe> GetRecipeById(string recipeId); // Obtener una receta por ID
        Task AddRecipe(Recipe recipe); // Añadir una nueva receta
        Task UpdateRecipe(Recipe recipe); // Actualizar una receta existente
        Task DeleteRecipe(string recipeId); // Eliminar una receta
    }
}




