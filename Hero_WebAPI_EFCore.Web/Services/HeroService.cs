using Hero_WebAPI_EFCore.DAL.Repositories.Interfaces;
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
            throw new NotImplementedException();
        }

        public HeroViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(HeroViewModel model)
        {
            throw new NotImplementedException();
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
