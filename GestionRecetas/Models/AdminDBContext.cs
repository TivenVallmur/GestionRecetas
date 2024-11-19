using GestionRecetas.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionRecetas.Data
{
    public class AdminDBContext : DbContext
    {
        public AdminDBContext(DbContextOptions<AdminDBContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        //public DbSet<User> Users { get; set; }
    }
}
