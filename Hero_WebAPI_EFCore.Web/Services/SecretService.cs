using Hero_WebAPI_EFCore.Web.Models;
using Hero_WebAPI_EFCore.Web.Services.Interfaces;

namespace Hero_WebAPI_EFCore.Web.Services
{
    public class SecretService : ISecretService
    {
        private readonly ISecretService _secretService;

        public SecretService(ISecretService secretService)
        {
            _secretService = secretService;
        }

        public List<SecretViewModel> Get()
        {
            throw new NotImplementedException();
        }

        public SecretViewModel GetById(int id)
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
