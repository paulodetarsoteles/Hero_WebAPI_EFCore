using AutoMapper;
using Hero_WebAPI_EFCore.DAL.Repositories.Interfaces;
using Hero_WebAPI_EFCore.Domain.Models;
using Hero_WebAPI_EFCore.Web.Models;
using Hero_WebAPI_EFCore.Web.Services.Interfaces;

namespace Hero_WebAPI_EFCore.Web.Services
{
    public class HeroService : IHeroService
    {
        private readonly IHeroRepository _heroRepository;
        private readonly IMapper _mapper;

        public HeroService(IHeroRepository heroRepository, IMapper mapper)
        {
            _heroRepository = heroRepository;
            _mapper = mapper;
        }

        public List<HeroViewModel> Get()
        {
            try
            {
                List<Hero> entities = _heroRepository.Get();

                if (entities is null || entities.Count == 0)
                    return null;

                return _mapper.Map<List<HeroViewModel>>(entities);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public HeroViewModel GetById(int id)
        {
            try
            {
                Hero entity = _heroRepository.GetById(id);

                if (entity is null)
                    return null;

                return _mapper.Map<HeroViewModel>(entity);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public HeroViewModel GetByName(string name)
        {
            try
            {
                Hero entity = _heroRepository.GetByName(name);

                if (entity is null)
                    return null;

                return _mapper.Map<HeroViewModel>(entity);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Insert(HeroViewModel model)
        {
            try
            {
                if (_heroRepository.GetByName(model.Name) is not null)
                    throw new Exception("Nome já consta na base de dados.");

                Hero entity = _mapper.Map<Hero>(model);

                return _heroRepository.Insert(entity);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Update(HeroViewModel model)
        {
            try
            {
                if (_heroRepository.GetById(model.HeroId) is null)
                    throw new Exception("Modelo não encontrado.");

                Hero entity = _mapper.Map<Hero>(model);

                return _heroRepository.Update(entity);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Delete(HeroViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
