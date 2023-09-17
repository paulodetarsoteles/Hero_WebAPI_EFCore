using Hero_WebAPI_EFCore.Web.Models;

namespace Hero_WebAPI_EFCore.Web.Services.Interfaces
{
    public interface ISecretService
    {
        List<SecretViewModel> Get();
        SecretViewModel GetById(int id);
        bool Insert(SecretViewModel model);
        bool Update(SecretViewModel model);
        bool Delete(SecretViewModel model);
    }
}
