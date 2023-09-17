namespace Hero_WebAPI_EFCore.Web.Models
{
    public class HeroMovieViewModel
    {
        public int HeroId { get; set; }
        public int MovieId { get; set; }

        public HeroViewModel Hero { get; set; }
        public MovieViewModel Movie { get; set; }
    }
}
