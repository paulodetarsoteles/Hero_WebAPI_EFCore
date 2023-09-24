﻿using AutoMapper;
using Hero_WebAPI_EFCore.DAL.Repositories.Interfaces;
using Hero_WebAPI_EFCore.Domain.Models;
using Hero_WebAPI_EFCore.Web.Models;
using Hero_WebAPI_EFCore.Web.Services.Interfaces;

namespace Hero_WebAPI_EFCore.Web.Services
{
    public class SecretService : ISecretService
    {
        private readonly ISecretRepository _secretRepository;
        private readonly IMapper _mapper;

        public SecretService(ISecretRepository secretRepository, IMapper mapper)
        {
            _secretRepository = secretRepository;
            _mapper = mapper;
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

                if (entity.Hero is null)
                    return new SecretViewModel
                    {
                        SecretId = entity.SecretId,
                        Name = entity.Name,
                        HeroId = entity.HeroId
                    };

                HeroViewModel heroModel = new()
                {
                    HeroId = entity.Hero.HeroId,
                    Name = entity.Hero.Name,
                    Active = entity.Hero.Active,
                    UpdateDate = entity.Hero.UpdateDate
                };

                return new SecretViewModel
                {
                    SecretId = entity.SecretId,
                    Name = entity.Name,
                    HeroId = entity.HeroId,
                    Hero = heroModel
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

                if (entity.Hero is null)
                    return new SecretViewModel
                    {
                        SecretId = entity.SecretId,
                        Name = entity.Name,
                        HeroId = entity.HeroId
                    };

                HeroViewModel heroModel = new()
                {
                    HeroId = entity.Hero.HeroId,
                    Name = entity.Hero.Name,
                    Active = entity.Hero.Active,
                    UpdateDate = entity.Hero.UpdateDate
                };

                return new SecretViewModel
                {
                    SecretId = entity.SecretId,
                    Name = entity.Name,
                    HeroId = entity.HeroId,
                    Hero = heroModel
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
            try
            {
                if (_secretRepository.GetById(model.SecretId) is null)
                    throw new Exception("Modelo não encontrado.");

                Secret secret = _secretRepository.GetByName(model.Name);

                if (secret is not null && secret.SecretId != model.SecretId)
                    throw new Exception("Nome já consta na base de dados.");

                if (model.HeroId is not null)
                {
                    if (!_secretRepository.HasHero((int)model.HeroId))
                        throw new Exception("Não há herói com este Id na base de dados.");

                    if (_secretRepository.HasHeroRelation((int)model.HeroId))
                        throw new Exception("Já existe um herói vinculado a essa identidade.");
                }

                Secret entity = _mapper.Map<Secret>(model);

                return _secretRepository.Update(entity);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Delete(SecretViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
