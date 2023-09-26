using Hero_WebAPI_EFCore.DAL.Data;
using Hero_WebAPI_EFCore.DAL.Repositories.Interfaces;
using Hero_WebAPI_EFCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Hero_WebAPI_EFCore.DAL.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext _dataContext;

        public MovieRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Movie> Get()
        {
            try
            {
                return _dataContext.Movies.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception($"Erro no banco de dados.");
            }
        }

        public Movie? GetById(int id)
        {
            try
            {
                Movie movie;

                try
                {
                    movie = _dataContext.Movies.AsNoTracking()
                        .Include(h => h.HeroesMovies)
                        .ThenInclude(h => h.Hero)
                        .First(h => h.MovieId == id);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }

                return movie;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception($"Erro no banco de dados.");
            }
        }

        public Movie? GetByName(string name)
        {
            try
            {
                Movie movie;

                try
                {
                    movie = _dataContext.Movies.AsNoTracking()
                        .Include(h => h.HeroesMovies)
                        .ThenInclude(h => h.Hero)
                        .First(h => h.Name == name);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }

                return movie;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception($"Erro no banco de dados.");
            }
        }

        public bool HasHeroRelation(int id)
        {
            try
            {
                return _dataContext.HeroesMovies.AsNoTracking().Any(h => h.MovieId == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception($"Erro no banco de dados.");
            }
        }

        public bool Insert(Movie entity)
        {
            try
            {
                EntityEntry<Movie> entityEntry = _dataContext.Movies.Add(entity);

                if (entityEntry is null)
                    return false;

                int entitiesSaved = _dataContext.SaveChanges();

                if (entitiesSaved <= 0)
                    return false;

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception($"Erro no banco de dados.");
            }
        }

        public bool Update(Movie entity)
        {
            try
            {
                EntityEntry<Movie> entityEntry = _dataContext.Movies.Update(entity);

                if (entityEntry is null)
                    return false;

                int entitiesSaved = _dataContext.SaveChanges();

                if (entitiesSaved <= 0)
                    return false;

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception($"Erro no banco de dados.");
            }
        }

        public bool Delete(int id)
        {
            try
            {
                Movie entity = _dataContext.Movies.AsNoTracking().First(h => h.MovieId == id);
                EntityEntry<Movie> entityEntry = _dataContext.Movies.Remove(entity);

                if (entityEntry is null)
                    return false;

                int entityRemoved = _dataContext.SaveChanges();

                if (entityRemoved <= 0)
                    return false;

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception($"Erro no banco de dados.");
            }
        }
    }
}
