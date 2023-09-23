using AutoMapper;
using Hero_WebAPI_EFCore.DAL.Repositories.Interfaces;
using Hero_WebAPI_EFCore.Domain.Models;
using Hero_WebAPI_EFCore.Web.Models;
using Hero_WebAPI_EFCore.Web.Services.Interfaces;

namespace Hero_WebAPI_EFCore.Web.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public List<MovieViewModel> Get()
        {
            try
            {
                List<Movie> entities = _movieRepository.Get();

                if (entities is null || entities.Count == 0)
                    return null;

                return _mapper.Map<List<MovieViewModel>>(entities);
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

                return _mapper.Map<MovieViewModel>(entity);
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

                return _mapper.Map<MovieViewModel>(entity);
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

                Movie entity = _mapper.Map<Movie>(model);

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
