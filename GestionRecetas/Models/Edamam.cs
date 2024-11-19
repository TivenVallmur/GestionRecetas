using Newtonsoft.Json;

namespace GestionRecetas.Models
{
    public class Edamam
    {
        //public class EdamamResponse
        //{
        //    public List<Recipe> Recipes { get; set; }
        //}
              
        public class EdamamResponse
        {
            public string q { get; set; }
            public int from { get; set; }
            public int to { get; set; }
            public bool more { get; set; }
            public int count { get; set; }
            public List<Hit> hits { get; set; }
        }

        public class Links
        {
            public Link self { get; set; }
            public Link next { get; set; }
        }

        public class Link
        {
            public string href { get; set; }
            public string title { get; set; }
        }

        public class Images
        {
            public ImageDetails thumbnail { get; set; }
            public ImageDetails small { get; set; }
            public ImageDetails regular { get; set; }
            public ImageDetails large { get; set; }
        }

        public class ImageDetails
        {
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Nutrient
        {
            public string label { get; set; }
            public double quantity { get; set; }
            public string unit { get; set; }
        }

        public class Digest
        {
            public string label { get; set; }
            public string tag { get; set; }
            public string schemaOrgTag { get; set; }
            public double total { get; set; }
            public bool hasRDI { get; set; }
            public double daily { get; set; }
            public string unit { get; set; }
            public List<Sub> sub { get; set; }
        }        

        public class Hit
        {
            public RecipeInfo recipe { get; set; }
        }

        public class Ingredient
        {
            public string text { get; set; }
            public double quantity { get; set; }
            public string measure { get; set; }
            public string food { get; set; }
            public double weight { get; set; }
            public string foodCategory { get; set; }
            public string foodId { get; set; }
            public string image { get; set; }
        }

        public class RecipeInfo
        {
            public string uri { get; set; }
            public string label { get; set; }
            public string image { get; set; }
            public string source { get; set; }
            public string url { get; set; }
            public string shareAs { get; set; }
            public double yield { get; set; }
            public List<string> dietLabels { get; set; }
            public List<string> healthLabels { get; set; }
            public List<string> cautions { get; set; }
            public List<string> ingredientLines { get; set; }
            public List<Ingredient> ingredients { get; set; }
            public double calories { get; set; }
            public double totalWeight { get; set; }
            public double totalTime { get; set; }
            public List<string> cuisineType { get; set; }
            public List<string> mealType { get; set; }
            public List<string> dishType { get; set; }
            public TotalNutrients totalNutrients { get; set; }
            public TotalDaily totalDaily { get; set; }
            public List<Digest> digest { get; set; }
            public List<string> tags { get; set; }
        }

        public class Sub
        {
            public string label { get; set; }
            public string tag { get; set; }
            public string schemaOrgTag { get; set; }
            public double total { get; set; }
            public bool hasRDI { get; set; }
            public double daily { get; set; }
            public string unit { get; set; }
        }

        public class TotalDaily
        {
            public Nutrient ENERC_KCAL { get; set; }
            public Nutrient FAT { get; set; }
            public Nutrient FASAT { get; set; }
            public Nutrient CHOCDF { get; set; }
            public Nutrient FIBTG { get; set; }
            public Nutrient PROCNT { get; set; }
            public Nutrient CHOLE { get; set; }
            public Nutrient NA { get; set; }
            public Nutrient CA { get; set; }
            public Nutrient MG { get; set; }
            public Nutrient K { get; set; }
            public Nutrient FE { get; set; }
            public Nutrient ZN { get; set; }
            public Nutrient P { get; set; }
            public Nutrient VITA_RAE { get; set; }
            public Nutrient VITC { get; set; }
            public Nutrient THIA { get; set; }
            public Nutrient RIBF { get; set; }
            public Nutrient NIA { get; set; }
            public Nutrient VITB6A { get; set; }
            public Nutrient FOLDFE { get; set; }
            public Nutrient VITB12 { get; set; }
            public Nutrient VITD { get; set; }
            public Nutrient TOCPHA { get; set; }
            public Nutrient VITK1 { get; set; }
        }

        public class TotalNutrients
        {
            public Nutrient ENERC_KCAL { get; set; }
            public Nutrient FAT { get; set; }
            public Nutrient FASAT { get; set; }
            public Nutrient FATRN { get; set; }
            public Nutrient FAMS { get; set; }
            public Nutrient FAPU { get; set; }
            public Nutrient CHOCDF { get; set; }

            [JsonProperty("CHOCDF.net")]
            public Nutrient CHOCDFnet { get; set; }
            public Nutrient FIBTG { get; set; }
            public Nutrient SUGAR { get; set; }
            public Nutrient PROCNT { get; set; }
            public Nutrient CHOLE { get; set; }
            public Nutrient NA { get; set; }
            public Nutrient CA { get; set; }
            public Nutrient MG { get; set; }
            public Nutrient K { get; set; }
            public Nutrient FE { get; set; }
            public Nutrient ZN { get; set; }
            public Nutrient P { get; set; }
            public Nutrient VITA_RAE { get; set; }
            public Nutrient VITC { get; set; }
            public Nutrient THIA { get; set; }
            public Nutrient RIBF { get; set; }
            public Nutrient NIA { get; set; }
            public Nutrient VITB6A { get; set; }
            public Nutrient FOLDFE { get; set; }
            public Nutrient FOLFD { get; set; }
            public Nutrient FOLAC { get; set; }
            public Nutrient VITB12 { get; set; }
            public Nutrient VITD { get; set; }
            public Nutrient TOCPHA { get; set; }
            public Nutrient VITK1 { get; set; }
            public Nutrient WATER { get; set; }
        }

    }
}
