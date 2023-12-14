using Amber_HealthAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amber_Health.Models
{
    public class BookingVM
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public int ContactId { get; set; }
        public int ProfessionId { get; set; }
        public int ParishId { get; set; }
        public DateTime Date { get; set; }

        
        public virtual Contact? Contact { get; set; }
       
        public virtual Profession? Profession { get; set; }
      
        public virtual Parish? Parish { get; set; }
    }
}
