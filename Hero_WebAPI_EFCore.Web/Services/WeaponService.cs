using Hero_WebAPI_EFCore.DAL.Repositories.Interfaces;
using Hero_WebAPI_EFCore.Domain.Models;
using Hero_WebAPI_EFCore.Web.Models;
using Hero_WebAPI_EFCore.Web.Services.Interfaces;

namespace Hero_WebAPI_EFCore.Web.Services
{
    public class WeaponService : IWeaponService
    {
        private readonly IWeaponRepository _weaponRepository;

        public WeaponService(IWeaponRepository weaponRepository)
        {
            _weaponRepository = weaponRepository;
        }

        public List<WeaponViewModel> Get()
        {
            try
            {
                List<Weapon> entities = _weaponRepository.Get();

                if (entities is null || entities.Count == 0)
                    return null;

                List<WeaponViewModel> models = new();

                foreach (Weapon weapon in entities)
                {
                    models.Add(new WeaponViewModel
                    {
                        WeaponId = weapon.WeaponId,
                        Name = weapon.Name,
                        HeroId = weapon.HeroId
                    });
                }

                return models;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public WeaponViewModel GetById(int id)
        {
            try
            {
                Weapon entity = _weaponRepository.GetById(id);

                if (entity is null)
                    return null;

                return new WeaponViewModel
                {
                    WeaponId = entity.WeaponId,
                    Name = entity.Name,
                    HeroId = entity.HeroId
                };
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public WeaponViewModel GetByName(string name)
        {
            try
            {
                Weapon entity = _weaponRepository.GetByName(name);

                if (entity is null)
                    return null;

                return new WeaponViewModel
                {
                    WeaponId = entity.WeaponId,
                    Name = entity.Name,
                    HeroId = entity.HeroId
                };
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Insert(WeaponViewModel model)
        {
            try
            {
                if (_weaponRepository.GetByName(model.Name) is not null)
                    throw new Exception("Nome já consta na base de dados.");

                Weapon entity = new()
                {
                    Name = model.Name,
                    HeroId = model.HeroId
                };

                return _weaponRepository.Insert(entity);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Update(WeaponViewModel model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(WeaponViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
