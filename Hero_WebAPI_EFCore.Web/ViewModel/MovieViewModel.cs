namespace Hero_WebAPI_EFCore.Web.Models
{
    public class MovieViewModel
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; }

        public List<HeroMovieViewModel> HeroesMovies { get; set; }
    }
}
