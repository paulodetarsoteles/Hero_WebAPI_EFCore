using AutoMapper;
using Hero_WebAPI_EFCore.Domain.Models;
using Hero_WebAPI_EFCore.Web.Models;

namespace Hero_WebAPI_EFCore.Web.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Movie, MovieViewModel>();
            CreateMap<MovieViewModel, Movie>();
            CreateMap<HeroMovie, HeroMovieViewModel>();
            CreateMap<HeroMovieViewModel, HeroMovie>();
            CreateMap<Hero, HeroViewModel>();
            CreateMap<HeroViewModel, Hero>();//.ForMember(x => x.Weapons, opt => opt.Ignore());
            CreateMap<Weapon, WeaponViewModel>();
            CreateMap<WeaponViewModel, Weapon>();
            CreateMap<Secret, SecretViewModel>();
            CreateMap<SecretViewModel, Secret>();
        }
    }
}
