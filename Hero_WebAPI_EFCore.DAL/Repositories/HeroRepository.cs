using Hero_WebAPI_EFCore.DAL.Data;
using Hero_WebAPI_EFCore.DAL.Repositories.Interfaces;
using Hero_WebAPI_EFCore.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Hero_WebAPI_EFCore.DAL.Repositories
{
    public class HeroRepository : IHeroRepository
    {
        private readonly DataContext _dataContext;

        public HeroRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Hero> Get()
        {
            try
            {
                return _dataContext.Heroes.AsNoTracking().ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception($"Erro no banco de dados.");
            }
        }

        public Hero? GetById(int id)
        {
            try
            {
                Hero hero;

                try
                {
                    hero = _dataContext.Heroes.AsNoTracking()
                        .Include(h => h.Secret)
                        .Include(h => h.Weapons)
                        .Include(h => h.HeroesMovies)
                        .First(h => h.HeroId == id);

                    return hero;
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

        public Hero? GetByName(string name)
        {
            try
            {
                Hero hero;

                try
                {
                    hero = _dataContext.Heroes.AsNoTracking()
                        .Include(h => h.Secret)
                        .Include(h => h.Weapons)
                        .Include(h => h.HeroesMovies)
                        .First(h => h.Name == name);

                    return hero;
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

        public bool Insert(Hero entity)
        {
            try
            {
                _dataContext.Heroes.Add(entity);
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

        public bool Update(Hero entity)
        {
            try
            {
                _dataContext.Heroes.Update(entity);
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

        public bool Delete(Hero entity)
        {
            throw new NotImplementedException();
        }
    }
}
