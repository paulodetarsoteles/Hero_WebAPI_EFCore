namespace Hero_WebAPI_EFCore.Web.Models
{
    public class SecretViewModel
    {
        public int SecretId { get; set; }
        public string Name { get; set; }
        public int HeroId { get; set; }

        public HeroViewModel Hero { get; set; }
    }
}
