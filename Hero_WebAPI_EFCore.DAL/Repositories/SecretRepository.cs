﻿using Hero_WebAPI_EFCore.DAL.Data;
using Hero_WebAPI_EFCore.DAL.Repositories.Interfaces;
using Hero_WebAPI_EFCore.Domain.Models;

namespace Hero_WebAPI_EFCore.DAL.Repositories
{
    public class SecretRepository : ISecretRepository
    {
        private readonly DataContext _dataContext;

        public SecretRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Secret> Get()
        {
            try
            {
                return _dataContext.Secrets.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception($"Erro no banco de dados.");
            }
        }

        public Secret? GetById(int id)
        {
            try
            {
                Secret secret;

                try
                {
                    secret = _dataContext.Secrets.First(h => h.SecretId == id);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }

                return secret;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception($"Erro no banco de dados.");
            }
        }

        public Secret? GetByName(string name)
        {
            try
            {
                Secret secret;

                try
                {
                    secret = _dataContext.Secrets.First(h => h.Name == name);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }

                return secret;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception($"Erro no banco de dados.");
            }
        }

        public bool Insert(Secret entity)
        {
            try
            {
                _dataContext.Secrets.Add(entity);
                int entitiesSaved = _dataContext.SaveChanges();

                if (entitiesSaved <= 0)
                    return false;

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception($"Erro no banco de dados.");
            }
        }

        public bool Update(Secret entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Secret entity)
        {
            throw new NotImplementedException();
        }
    }
}
