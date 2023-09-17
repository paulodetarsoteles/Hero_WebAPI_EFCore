using Hero_WebAPI_EFCore.DAL.Repositories.Interfaces;
using Hero_WebAPI_EFCore.Domain.Models;
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
            try
            {
                List<Secret> entities = _secretRepository.Get();

                if (entities is null || entities.Count == 0)
                    return null;

                List<SecretViewModel> models = new();

                foreach (Secret secret in entities)
                {
                    models.Add(new SecretViewModel
                    {
                        SecretId = secret.SecretId,
                        Name = secret.Name,
                        HeroId = secret.HeroId
                    });
                }

                return models;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public SecretViewModel GetById(int id)
        {
            try
            {
                Secret entity = _secretRepository.GetById(id);

                if (entity is null)
                    return null;

                return new SecretViewModel
                {
                    SecretId = entity.SecretId,
                    Name = entity.Name,
                    HeroId = entity.HeroId
                };
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public SecretViewModel GetByName(string name)
        {
            try
            {
                Secret entity = _secretRepository.GetByName(name);

                if (entity is null)
                    return null;

                return new SecretViewModel
                {
                    SecretId = entity.SecretId,
                    Name = entity.Name,
                    HeroId = entity.HeroId
                };
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Insert(SecretViewModel model)
        {
            try
            {
                if (_secretRepository.GetByName(model.Name) is not null)
                    throw new Exception("Nome já consta na base de dados.");

                Secret entity = new()
                {
                    Name = model.Name,
                    HeroId = model.HeroId
                };

                return _secretRepository.Insert(entity);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
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
