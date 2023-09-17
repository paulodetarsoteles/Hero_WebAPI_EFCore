using Hero_WebAPI_EFCore.Domain.Models;

namespace Hero_WebAPI_EFCore.DAL.Repositories.Interfaces
{
    public interface IWeaponRepository
    {
        List<Weapon> Get();
        Weapon? GetById(int id);
        Weapon? GetByName(string id);
        bool Insert(Weapon entity);
        bool Update(Weapon entity);
        bool Delete(Weapon entity);
    }
}
