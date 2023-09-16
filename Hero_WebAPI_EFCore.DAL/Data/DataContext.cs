using Hero_WebAPI_EFCore.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Hero_WebAPI_EFCore.DAL.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Secret> Secrets { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<HeroMovie> HeroesMovies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;DataBase=Hero_WebAPI_EFCore_DB;Uid=developer;Pwd=1234567");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroMovie>(entity =>
            {
                entity.HasKey(e => new
                {
                    e.HeroId,
                    e.MovieId
                });
            });
        }
    }
}
