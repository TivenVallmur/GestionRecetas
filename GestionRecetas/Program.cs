using GestionRecetas.Interfaces;
using GestionRecetas.Services;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddControllersWithViews();

// Registrar HttpClient para SpoonacularService
//builder.Services.AddHttpClient<IEdamamService, EdamamService>();
//builder.Services.AddHttpClient<ITheMealDbService, TheMealDbService>();
//builder.Services.AddHttpClient<IRecipeService, RecipeService>();

var app = builder.Build();

// Configurar el pipeline de manejo de errores
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Muestra detalles de las excepciones en modo desarrollo
}
else
{
    app.UseExceptionHandler("/Home/Error"); // Redirige a la p�gina de error en producci�n
    app.UseHsts(); // Aplicar la pol�tica HSTS en producci�n
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
