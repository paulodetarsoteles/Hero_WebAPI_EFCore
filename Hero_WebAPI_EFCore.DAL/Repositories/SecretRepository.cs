using Hero_WebAPI_EFCore.DAL.Data;
using Hero_WebAPI_EFCore.DAL.Repositories.Interfaces;
using Hero_WebAPI_EFCore.Domain.Models;

namespace Hero_WebAPI_EFCore.DAL.Repositories
{
    public class SecretRepository : ISecretRepository
    {
        private readonly DataContext _dataContext;

        public SecretRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Secret> Get()
        {
            throw new NotImplementedException();
        }

        public Secret GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Secret? GetByName(string id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Secret entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Secret entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Secret entity)
        {
            throw new NotImplementedException();
        }
    }
}
