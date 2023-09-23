using System.ComponentModel.DataAnnotations;

namespace Hero_WebAPI_EFCore.Domain.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Rate { get; set; }


        public List<HeroMovie> HeroesMovies { get; set; }
    }
}
