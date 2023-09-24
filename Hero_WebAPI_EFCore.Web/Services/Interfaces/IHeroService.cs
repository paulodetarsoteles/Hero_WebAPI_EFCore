using Hero_WebAPI_EFCore.Web.Models;

namespace Hero_WebAPI_EFCore.Web.Services.Interfaces
{
    public interface IHeroService
    {
        List<HeroViewModel> Get();
        HeroViewModel GetById(int id);
        HeroViewModel GetByName(string name);
        bool Insert(HeroViewModel model);
        bool Update(HeroViewModel model);
        bool Delete(int id);
    }
}
