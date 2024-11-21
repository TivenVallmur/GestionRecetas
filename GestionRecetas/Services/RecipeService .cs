using GestionRecetas.Data;
using GestionRecetas.Interfaces;
using GestionRecetas.Models;
using System.Collections.Generic; // Para List<>
using System.Linq; // Para FirstOrDefault
using System.Threading.Tasks; // Para Task
using Microsoft.EntityFrameworkCore;

namespace GestionRecetas.Services
{
    public class RecipeService : IDatabaseRecipeService
    {
        private readonly AdminDBContext _context;

        public RecipeService(AdminDBContext  context)
        {
            _context = context;
        }
                
        public async Task<Recipe> GetRecipeById(string recipeId)
        {
            //Consultar la base de datos filtrando por id y retornar la receta.
            Recipe recipe = _context.Recipes.Where(p => p.Id.Trim() == recipeId).FirstOrDefault();
            
            return recipe;
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
