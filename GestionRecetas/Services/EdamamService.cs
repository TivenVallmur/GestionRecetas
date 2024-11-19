using GestionRecetas.Interfaces;
using GestionRecetas.Models;
using Newtonsoft.Json;
using System.Linq;
using static GestionRecetas.Models.Edamam;

namespace GestionRecetas.Services
{
    public class EdamamService : IEdamamService
    {
        private readonly HttpClient _httpClient;

        Recipe _recipe = new Recipe();

        public EdamamService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Recipe>> GetRecipesByCountry(string country)
        {
            List<Recipe> List = new List<Recipe>();

            try
            {
                //var response = await _httpClient.GetStringAsync($"https://api.spoonacular.com/recipes/complexSearch?apiKey=4264f2526bed4670b12cffc26ee0daa8&cuisine={country}");
                var response = await _httpClient.GetStringAsync($"https://api.edamam.com/search?q=recipe&cuisineType={country}&app_id=ac52b010&app_key=00191407047a76ff463fdfba9f4bbca4&to=1");
                var result = JsonConvert.DeserializeObject<EdamamResponse>(response);

                var recipes = result.hits.Select(hit =>
                    RecipeMapper.MapToRecipe(
                        hit.recipe.uri.Split("#")[1],
                        hit.recipe.label,                        
                        hit.recipe.url,
                        hit.recipe.ingredientLines.ToList(),
                        hit.recipe.cuisineType.ToList()
                    )
                ).ToList();

                List.AddRange(recipes);                
            }
            catch (Exception ex)
            {
                var mensaje = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
            return List;
        }

        public async Task<Recipe> GetRecipeDetails(string recipeId)
        {
            Recipe recipe = new Recipe();

            try
            {                
                var response = await _httpClient.GetStringAsync($"https://api.edamam.com/api/recipes/v2/{recipeId}?type=public&app_id=ac52b010&app_key=00191407047a76ff463fdfba9f4bbca4");
                recipe = JsonConvert.DeserializeObject<Recipe>(response);                                 
            }
            catch (Exception ex)
            {
                var mensaje = ex.InnerException != null ? ex.InnerException.Message : ex.Message;                
            }

            return recipe;


        }
    }
}
