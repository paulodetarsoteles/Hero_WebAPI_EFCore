using Hero_WebAPI_EFCore.Domain.Models;
using System.Dynamic;

namespace Hero_WebAPI_EFCore.DAL.Repositories.Interfaces
{
    public interface IHeroRepository
    {
        List<Hero> Get();
        Hero GetById(int id);
        bool Insert(Hero entity);
        bool Update(Hero entity);
        bool Delete(Hero entity);
    }
}
