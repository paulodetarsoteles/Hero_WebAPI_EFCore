using Hero_WebAPI_EFCore.DAL.Data;
using Hero_WebAPI_EFCore.DAL.Repositories.Interfaces;
using Hero_WebAPI_EFCore.Domain.Models;

namespace Hero_WebAPI_EFCore.DAL.Repositories
{
    public class WeaponRepository : IWeaponRepository
    {
        private readonly DataContext _dataContext;

        public WeaponRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Weapon> Get()
        {
            throw new NotImplementedException();
        }

        public Weapon GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Weapon entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Weapon entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Weapon entity)
        {
            throw new NotImplementedException();
        }
    }
}
