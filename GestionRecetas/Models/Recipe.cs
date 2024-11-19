namespace GestionRecetas.Models
{
    public class Recipe
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> Country { get; set; }        
        public List<string> Ingredients { get; set; }        
        public string ImageUrl { get; set; }
    }

    public static class RecipeMapper
    {
        public static Recipe MapToRecipe(string id, string name, string imageUrl, List<string> ingredients, List<string> country)
        {
            return new Recipe
            {
                Id = id,
                Name = name,
                ImageUrl = imageUrl,
                Ingredients = ingredients,
                Country = country,
            };
        }
    }
}
