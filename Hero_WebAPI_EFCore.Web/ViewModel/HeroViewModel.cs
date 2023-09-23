using System.ComponentModel.DataAnnotations;

namespace Hero_WebAPI_EFCore.Web.Models
{
    public class HeroViewModel
    {
        public int HeroId { get; set; }

        [Required(ErrorMessage = "Nome requerido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo Active requerido")]
        public bool Active { get; set; }

        public DateTime UpdateDate { get; set; }


        public SecretViewModel Secret { get; set; }
        public List<WeaponViewModel> Weapons { get; set; }
        public List<HeroMovieViewModel> HeroesMovies { get; set; }
    }
}
