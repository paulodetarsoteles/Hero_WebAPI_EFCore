﻿using Hero_WebAPI_EFCore.DAL.Data;
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
            throw new NotImplementedException();
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
