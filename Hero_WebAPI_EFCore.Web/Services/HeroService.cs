using Hero_WebAPI_EFCore.DAL.Repositories.Interfaces;
using Hero_WebAPI_EFCore.Domain.Models;
using Hero_WebAPI_EFCore.Web.Models;
using Hero_WebAPI_EFCore.Web.Services.Interfaces;

namespace Hero_WebAPI_EFCore.Web.Services
{
    public class HeroService : IHeroService
    {
        private readonly IHeroRepository _heroRepository;

        public HeroService(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }

        public List<HeroViewModel> Get()
        {
            try
            {
                List<Hero> entities = _heroRepository.Get();

                if (entities is null || entities.Count == 0)
                    return null;

                List<HeroViewModel> models = new();

                foreach (Hero hero in entities)
                {
                    models.Add(new HeroViewModel
                    {
                        HeroId = hero.HeroId,
                        Name = hero.Name,
                        Active = hero.Active,
                        UpdateDate = hero.UpdateDate
                    });
                }

                return models;
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

                return new HeroViewModel
                {
                    HeroId = entity.HeroId,
                    Name = entity.Name,
                    Active = entity.Active,
                    UpdateDate = entity.UpdateDate
                };
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
                Hero entity = new()
                {
                    Name = model.Name,
                    Active = model.Active,
                    UpdateDate = model.UpdateDate
                };

                return _heroRepository.Insert(entity);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Update(HeroViewModel model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(HeroViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
