using Hero_WebAPI_EFCore.Web.Models;

namespace Hero_WebAPI_EFCore.Web.Services.Interfaces
{
    public interface IWeaponService
    {
        List<WeaponViewModel> Get();
        WeaponViewModel GetById(int id);
        WeaponViewModel GetByName(string name);
        bool Insert(WeaponViewModel model);
        bool Update(WeaponViewModel model);
        bool Delete(int id);
    }
}
