using Hero_WebAPI_EFCore.Domain.Models;

namespace Hero_WebAPI_EFCore.DAL.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        List<Movie> Get();
        Movie? GetById(int id);
        Movie? GetByName(string name);
        bool Insert(Movie entity);
        bool Update(Movie entity);
        bool Delete(Movie entity);
    }
}
