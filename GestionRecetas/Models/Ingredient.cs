namespace GestionRecetas.Models
{
    public class Ingredient
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; } // Unidad de medida (gramos, litros, etc.)
        public string ImageUrl { get; set; }
    }
}
