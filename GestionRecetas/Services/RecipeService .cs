using GestionRecetas.Data;
using GestionRecetas.Interfaces;
using GestionRecetas.Models;
using System.Collections.Generic; // Para List<>
using System.Linq; // Para FirstOrDefault
using System.Threading.Tasks; // Para Task
using Microsoft.EntityFrameworkCore;

namespace GestionRecetas.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly AdminDBContext _context;

        public RecipeService(AdminDBContext  context)
        {
            _context = context;
        }

        public async Task<List<Recipe>> GetAllRecipes()
        {
            return await _context.Recipes.ToListAsync(); // Obtener todas las recetas desde la base de datos
        }

        public async Task<Recipe> GetRecipeById(string recipeId)
        {
            return await _context.Recipes.FindAsync(recipeId); // Buscar receta por ID
        }

        public async Task<List<Recipe>> GetRecipesByCountry(string country)
        {
            return await _context.Recipes
                .Where(r => r.Country.Contains(country)).ToListAsync(); // Obtener recetas por país
        }

        public async Task AddRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe); // Añadir nueva receta
            await _context.SaveChangesAsync(); // Guardar cambios
        }

        public async Task UpdateRecipe(Recipe recipe)
        {
            _context.Recipes.Update(recipe); // Actualizar receta
            await _context.SaveChangesAsync(); // Guardar cambios
        }

        public async Task DeleteRecipe(string recipeId)
        {
            var recipe = await _context.Recipes.FindAsync(recipeId);
            if (recipe != null)
            {
                _context.Recipes.Remove(recipe); // Eliminar receta
                await _context.SaveChangesAsync(); // Guardar cambios
            }
        }
    }

}
