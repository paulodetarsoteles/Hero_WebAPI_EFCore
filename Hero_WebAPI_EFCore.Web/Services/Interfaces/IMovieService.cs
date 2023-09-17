using Hero_WebAPI_EFCore.Web.Models;

namespace Hero_WebAPI_EFCore.Web.Services.Interfaces
{
    public interface IMovieService
    {
        List<MovieViewModel> Get();
        MovieViewModel GetById(int id);
        bool Insert(MovieViewModel model);
        bool Update(MovieViewModel model);
        bool Delete(MovieViewModel model);
    }
}
