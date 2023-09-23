using System.ComponentModel.DataAnnotations;

namespace Hero_WebAPI_EFCore.Domain.Models
{
    public class Hero
    {
        [Key]
        public int HeroId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        public DateTime UpdateDate { get; set; }


        public Secret Secret { get; set; }
        public List<Weapon> Weapons { get; set; }
        public List<HeroMovie> HeroesMovies { get; set; }
    }
}
