using Hero_WebAPI_EFCore.DAL.Data;
using Hero_WebAPI_EFCore.DAL.Repositories.Interfaces;
using Hero_WebAPI_EFCore.Domain.Models;
using Microsoft.EntityFrameworkCore;

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
                return _dataContext.Weapons.AsNoTracking().ToList();
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
                    weapon = _dataContext.Weapons.AsNoTracking()
                        .Include(h => h.Hero)
                        .First(h => h.WeaponId == id);

                    return weapon;
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
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
                    weapon = _dataContext.Weapons.AsNoTracking()
                        .Include(h => h.Hero)
                        .First(h => h.Name == name);

                    return weapon;
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception($"Erro no banco de dados.");
            }
        }

        public bool HasHero(int id)
        {
            try
            {
                return _dataContext.Heroes.AsNoTracking().Any(h => h.HeroId == id);
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
            try
            {
                _dataContext.Weapons.Update(entity);
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

        public bool Delete(Weapon entity)
        {
            throw new NotImplementedException();
        }
    }
}
