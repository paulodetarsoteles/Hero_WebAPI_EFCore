﻿using Hero_WebAPI_EFCore.Domain.Models;

namespace Hero_WebAPI_EFCore.DAL.Repositories.Interfaces
{
    public interface ISecretRepository
    {
        List<Secret> Get();
        Secret? GetById(int id);
        Secret? GetByName(string id);
        bool HasHero(int id);
        bool HasHeroRelation(int id);
        bool Insert(Secret entity);
        bool Update(Secret entity);
        bool Delete(int id);
    }
}
