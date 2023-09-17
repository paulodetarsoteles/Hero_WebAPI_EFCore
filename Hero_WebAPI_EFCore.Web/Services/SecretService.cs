using Hero_WebAPI_EFCore.DAL.Repositories.Interfaces;
using Hero_WebAPI_EFCore.Web.Models;
using Hero_WebAPI_EFCore.Web.Services.Interfaces;

namespace Hero_WebAPI_EFCore.Web.Services
{
    public class SecretService : ISecretService
    {
        private readonly ISecretRepository _secretRepository;

        public SecretService(ISecretRepository secretRepository)
        {
            _secretRepository = secretRepository;
        }

        public List<SecretViewModel> Get()
        {
            throw new NotImplementedException();
        }

        public SecretViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public SecretViewModel GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Insert(SecretViewModel model)
        {
            throw new NotImplementedException();
        }

        public bool Update(SecretViewModel model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(SecretViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
