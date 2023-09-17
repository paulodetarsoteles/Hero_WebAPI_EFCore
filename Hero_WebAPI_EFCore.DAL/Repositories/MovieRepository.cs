using Hero_WebAPI_EFCore.DAL.Data;
using Hero_WebAPI_EFCore.DAL.Repositories.Interfaces;
using Hero_WebAPI_EFCore.Domain.Models;

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
                    movie = _dataContext.Movies.First(h => h.MovieId == id);
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
                    movie = _dataContext.Movies.First(h => h.Name == name);
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

        public bool Insert(Movie entity)
        {
            try
            {
                _dataContext.Movies.Add(entity);
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
            throw new NotImplementedException();
        }

        public bool Delete(Movie entity)
        {
            throw new NotImplementedException();
        }
    }
}
