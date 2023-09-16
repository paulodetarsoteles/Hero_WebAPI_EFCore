using Hero_WebAPI_EFCore.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Hero_WebAPI_EFCore.Web.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Secret> Secrets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;DataBase=Hero_WebAPI_EFCore_DB;Uid=developer;Pwd=1234567");
        }
    }
}
