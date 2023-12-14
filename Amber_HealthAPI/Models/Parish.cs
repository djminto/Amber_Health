using System.ComponentModel.DataAnnotations;

namespace Amber_HealthAPI.Models
{
    public class Parish
    {
        [Key]
        public int Id { get; set; }
        public string ParishName { get; set; }
    }
}
