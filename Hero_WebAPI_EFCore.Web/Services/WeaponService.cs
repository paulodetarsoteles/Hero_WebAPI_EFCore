﻿using Hero_WebAPI_EFCore.Web.Models;
using Hero_WebAPI_EFCore.Web.Services.Interfaces;

namespace Hero_WebAPI_EFCore.Web.Services
{
    public class WeaponService : IWeaponService
    {
        private readonly IWeaponService _weaponService;

        public WeaponService(IWeaponService weaponService)
        {
            _weaponService = weaponService;
        }

        public List<WeaponViewModel> Get()
        {
            throw new NotImplementedException();
        }

        public WeaponViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(WeaponViewModel model)
        {
            throw new NotImplementedException();
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
