using Hero_WebAPI_EFCore.DAL.Data;
using Hero_WebAPI_EFCore.DAL.Repositories;
using Hero_WebAPI_EFCore.DAL.Repositories.Interfaces;
using Hero_WebAPI_EFCore.Web.Services;
using Hero_WebAPI_EFCore.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddScoped<IHeroRepository, HeroRepository>();
        builder.Services.AddScoped<IMovieRepository, MovieRepository>();
        builder.Services.AddScoped<ISecretRepository, SecretRepository>();
        builder.Services.AddScoped<IWeaponRepository, WeaponRepository>();

        builder.Services.AddScoped<IHeroService, HeroService>();
        builder.Services.AddScoped<IMovieService, MovieService>();
        builder.Services.AddScoped<ISecretService, SecretService>();
        builder.Services.AddScoped<IWeaponService, WeaponService>();

        builder.Services.AddAutoMapper(typeof(Program));

        builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

        builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}