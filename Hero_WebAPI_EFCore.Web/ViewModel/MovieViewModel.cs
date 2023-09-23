using System.ComponentModel.DataAnnotations;

namespace Hero_WebAPI_EFCore.Web.Models
{
    public class MovieViewModel
    {
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Nome é requerido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Nome é requerido")]
        public int Rate { get; set; }


        public List<HeroMovieViewModel> HeroesMovies { get; set; }
    }
}
