using Hero_WebAPI_EFCore.Domain.Models;

namespace Hero_WebAPI_EFCore.DAL.Repositories.Interfaces
{
    public interface IHeroRepository
    {
        List<Hero> Get();
        Hero? GetById(int id);
        Hero? GetByName(string name);
        bool Insert(Hero entity);
        bool Update(Hero entity);
        bool Delete(Hero entity);
    }
}
