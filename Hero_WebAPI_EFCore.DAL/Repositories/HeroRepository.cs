using Hero_WebAPI_EFCore.DAL.Data;
using Hero_WebAPI_EFCore.DAL.Repositories.Interfaces;
using Hero_WebAPI_EFCore.Domain.Models;

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
            throw new NotImplementedException();
        }

        public Hero GetById(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public bool Delete(Hero entity)
        {
            throw new NotImplementedException();
        }
    }
}
