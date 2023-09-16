namespace Hero_WebAPI_EFCore.Domain.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; }

        public List<HeroMovie> HeroesMovies { get; set; }
    }
}
