using System.ComponentModel.DataAnnotations;

namespace Hero_WebAPI_EFCore.Domain.Models
{
    public class Secret
    {
        [Key]
        public int SecretId { get; set; }

        [Required]
        public string Name { get; set; }

        public int? HeroId { get; set; }


        public Hero Hero { get; set; }
    }
}
