﻿using Hero_WebAPI_EFCore.Web.Models;
using Hero_WebAPI_EFCore.Web.Services.Interfaces;

namespace Hero_WebAPI_EFCore.Web.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieService _movieService;

        public MovieService(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public List<MovieViewModel> Get()
        {
            throw new NotImplementedException();
        }

        public MovieViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(MovieViewModel model)
        {
            throw new NotImplementedException();
        }

        public bool Update(MovieViewModel model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(MovieViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
