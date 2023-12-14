using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amber_HealthAPI.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public int ContactId { get; set; }
        public int ProfessionId {  get; set; }
        public int ParishId { get; set; }
        public DateTime Date {  get; set; }
        
        [ForeignKey("ContactId")]
        public virtual Contact? Contact { get; set; }
        [ForeignKey("ProfessionId")]
        public virtual Profession? Profession { get; set; }
        [ForeignKey("ParishId")]
        public virtual Parish? Parish { get; set; }
    }
}
