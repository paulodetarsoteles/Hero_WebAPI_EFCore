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
            try
            {
                return _dataContext.Weapons.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception($"Erro no banco de dados.");
            }
        }

        public Weapon? GetById(int id)
        {
            try
            {
                Weapon weapon;

                try
                {
                    weapon = _dataContext.Weapons.First(h => h.WeaponId == id);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }

                return weapon;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception($"Erro no banco de dados.");
            }
        }

        public Weapon? GetByName(string name)
        {
            try
            {
                Weapon weapon;

                try
                {
                    weapon = _dataContext.Weapons.First(h => h.Name == name);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }

                return weapon;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception($"Erro no banco de dados.");
            }
        }

        public bool Insert(Weapon entity)
        {
            try
            {
                _dataContext.Weapons.Add(entity);
                int entitiesSaved = _dataContext.SaveChanges();

                if (entitiesSaved <= 0)
                    return false;

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception($"Erro no banco de dados.");
            }
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
