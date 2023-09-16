namespace Hero_WebAPI_EFCore.Web.Models
{
    public class Hero
    {
        public int HeroId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime UpdateDate { get; set; }

        public Secret Secret { get; set; }
        public List<Weapon> Weapons { get; set; }
        public List<HeroMovie> HeroesMovies { get; set; }
    }
}
