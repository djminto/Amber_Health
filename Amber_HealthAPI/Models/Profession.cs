using System.ComponentModel.DataAnnotations;

namespace Amber_HealthAPI.Models
{
    public class Profession
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Initials { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
