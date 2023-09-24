using AutoMapper;
using Hero_WebAPI_EFCore.DAL.Repositories.Interfaces;
using Hero_WebAPI_EFCore.Domain.Models;
using Hero_WebAPI_EFCore.Web.Models;
using Hero_WebAPI_EFCore.Web.Services.Interfaces;

namespace Hero_WebAPI_EFCore.Web.Services
{
    public class WeaponService : IWeaponService
    {
        private readonly IWeaponRepository _weaponRepository;
        private readonly IMapper _mapper;

        public WeaponService(IWeaponRepository weaponRepository, IMapper mapper)
        {
            _weaponRepository = weaponRepository;
            _mapper = mapper;
        }

        public List<WeaponViewModel> Get()
        {
            try
            {
                List<Weapon> entities = _weaponRepository.Get();

                if (entities is null || entities.Count == 0)
                    return null;

                List<WeaponViewModel> models = new();

                return _mapper.Map<List<WeaponViewModel>>(entities);
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

                return _mapper.Map<WeaponViewModel>(entity);
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

                return _mapper.Map<WeaponViewModel>(entity);
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

                return _weaponRepository.Insert(_mapper.Map<Weapon>(model));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Update(WeaponViewModel model)
        {
            try
            {
                if (_weaponRepository.GetById(model.WeaponId) is null)
                    throw new Exception("Modelo não encontrado.");

                Weapon weapon = _weaponRepository.GetByName(model.Name);

                if (weapon is not null && weapon.WeaponId != model.WeaponId)
                    throw new Exception("Nome já consta na base de dados.");

                if (model.HeroId is not null)
                {
                    if (!_weaponRepository.HasHero((int)model.HeroId))
                        throw new Exception("Não há herói com este Id na base de dados.");
                }

                return _weaponRepository.Update(_mapper.Map<Weapon>(model));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
