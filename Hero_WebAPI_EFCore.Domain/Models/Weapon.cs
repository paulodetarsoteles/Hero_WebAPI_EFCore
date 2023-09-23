using System.ComponentModel.DataAnnotations;

namespace Hero_WebAPI_EFCore.Domain.Models
{
    public class Weapon
    {
        [Key]
        public int WeaponId { get; set; }

        [Required]
        public string Name { get; set; }

        public int? HeroId { get; set; }


        public Hero Hero { get; set; }
    }
}
