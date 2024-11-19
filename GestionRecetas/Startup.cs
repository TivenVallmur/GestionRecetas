using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;
using GestionRecetas.Data;
using GestionRecetas.Interfaces;
using GestionRecetas.Services;

namespace GestionRecetas
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configuración de la cadena de conexión a la base de datos
            services.AddDbContext<AdminDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Aquí puedes registrar otros servicios, como el servicio para recetas
            services.AddScoped<IRecipeService, RecipeService>();

            // Otras configuraciones de servicios
            services.AddControllersWithViews(); // Si estás usando MVC
            // services.AddRazorPages(); // Si usas Razor Pages
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error"); // Página de error
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                // Si usas Razor Pages, puedes agregar esto:
                // endpoints.MapRazorPages();
            });
        }
    }
}
