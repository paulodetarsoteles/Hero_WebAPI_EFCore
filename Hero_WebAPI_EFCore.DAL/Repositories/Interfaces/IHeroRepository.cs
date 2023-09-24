using Hero_WebAPI_EFCore.Domain.Models;

namespace Hero_WebAPI_EFCore.DAL.Repositories.Interfaces
{
    public interface IHeroRepository
    {
        List<Hero> Get();
        Hero? GetById(int id);
        Hero? GetByName(string name);
        bool HasSecretRelation(int id);
        bool HasWeaponRelation(int id);
        bool HasMovieRelation(int id);
        bool Insert(Hero entity);
        bool Update(Hero entity);
        bool Delete(int id);
    }
}
