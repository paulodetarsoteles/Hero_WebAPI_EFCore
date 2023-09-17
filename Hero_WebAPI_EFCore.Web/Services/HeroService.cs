using Hero_WebAPI_EFCore.Web.Models;
using Hero_WebAPI_EFCore.Web.Services.Interfaces;

namespace Hero_WebAPI_EFCore.Web.Services
{
    public class HeroService : IHeroService
    {
        private readonly IHeroService _heroService;

        public HeroService(IHeroService heroService)
        {
            _heroService = heroService;
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
