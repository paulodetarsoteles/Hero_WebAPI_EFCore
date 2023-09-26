using Hero_WebAPI_EFCore.DAL.Data;
using Hero_WebAPI_EFCore.DAL.Repositories.Interfaces;
using Hero_WebAPI_EFCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
                EntityEntry<Weapon> entityEntry = _dataContext.Weapons.Add(entity);

                if (entityEntry is null)
                    return false;

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
                EntityEntry<Weapon> entityEntry = _dataContext.Weapons.Update(entity);

                if (entityEntry is null)
                    return false;

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

        public bool Delete(int id)
        {
            try
            {
                Weapon entity = _dataContext.Weapons.AsNoTracking().First(h => h.WeaponId == id);
                EntityEntry<Weapon> entityEntry = _dataContext.Weapons.Remove(entity);

                if (entityEntry is null)
                    return false;

                int entityRemoved = _dataContext.SaveChanges();

                if (entityRemoved <= 0)
                    return false;

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception($"Erro no banco de dados.");
            }
        }
    }
}
