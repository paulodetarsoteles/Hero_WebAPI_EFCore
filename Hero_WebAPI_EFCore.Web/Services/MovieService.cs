using Hero_WebAPI_EFCore.DAL.Repositories.Interfaces;
using Hero_WebAPI_EFCore.Domain.Models;
using Hero_WebAPI_EFCore.Web.Models;
using Hero_WebAPI_EFCore.Web.Services.Interfaces;

namespace Hero_WebAPI_EFCore.Web.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public List<MovieViewModel> Get()
        {
            try
            {
                List<Movie> entities = _movieRepository.Get();

                if (entities is null || entities.Count == 0)
                    return null;

                List<MovieViewModel> models = new();

                foreach (Movie movie in entities)
                {
                    models.Add(new MovieViewModel
                    {
                        MovieId = movie.MovieId,
                        Name = movie.Name,
                        Rate = movie.Rate
                    });
                }

                return models;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public MovieViewModel GetById(int id)
        {
            try
            {
                Movie entity = _movieRepository.GetById(id);

                if (entity is null)
                    return null;

                return new MovieViewModel
                {
                    MovieId = entity.MovieId,
                    Name = entity.Name,
                    Rate = entity.Rate
                };
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public MovieViewModel GetByName(string name)
        {
            try
            {
                Movie entity = _movieRepository.GetByName(name);

                if (entity is null)
                    return null;

                return new MovieViewModel
                {
                    MovieId = entity.MovieId,
                    Name = entity.Name,
                    Rate = entity.Rate
                };
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Insert(MovieViewModel model)
        {
            try
            {
                if (_movieRepository.GetByName(model.Name) is not null)
                    throw new Exception("Nome já consta na base de dados.");

                Movie entity = new()
                {
                    Name = model.Name,
                    Rate = model.Rate
                };

                return _movieRepository.Insert(entity);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Update(MovieViewModel model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(MovieViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
