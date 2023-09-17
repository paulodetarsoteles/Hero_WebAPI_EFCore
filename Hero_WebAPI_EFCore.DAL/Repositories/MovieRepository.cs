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
            throw new NotImplementedException();
        }

        public Movie GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Movie? GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Movie entity)
        {
            throw new NotImplementedException();
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
