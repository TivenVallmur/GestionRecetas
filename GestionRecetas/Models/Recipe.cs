using GestionRecetas.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using GestionRecetas.Services;

namespace GestionRecetas.Models
{
    public class Recipe
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> Country { get; set; }
        public List<string> Ingredients { get; set; }
        public string ImageUrl { get; set; }
        public RecipeProvider Provider { get; set; }
    }

    public static class RecipeMapper
    {
        public static Recipe MapToRecipe(string id, string name, string imageUrl, List<string> ingredients, List<string> country, RecipeProvider Provider)
        {
            return new Recipe
            {
                Id = id,
                Name = name,
                ImageUrl = imageUrl,
                Ingredients = ingredients,
                Country = country,
                Provider = Provider
            };
        }
    }

    public class RecipeFactory
    {
        public static IApiRecipeService GetRecipeService(string id)
        {
            switch (id)
            {
                case "Edamam":
                    return new EdamamService();
                case "TheMealdb":
                    return new TheMealDbServices();
                default:
                    throw new NotImplementedException($"No se ha implementado el servicio para: {id}");
            }
        }
    }

    public enum RecipeProvider
    {
        Edamam,
        TheMealDb
    }
}
