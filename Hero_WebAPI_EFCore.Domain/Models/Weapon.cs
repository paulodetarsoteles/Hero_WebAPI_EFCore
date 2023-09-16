namespace Hero_WebAPI_EFCore.Domain.Models
{
    public class Weapon
    {
        public int WeaponId { get; set; }
        public string Name { get; set; }
        public int HeroId { get; set; }

        public Hero Hero { get; set; }
    }
}
