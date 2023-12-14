using Amber_HealthAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Amber_HealthAPI.Data
{
    public class BookingDbContext : DbContext 
    {
        public BookingDbContext(DbContextOptions options) : base(options) 
        {
            
        }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Profession> Professions { get; set;}
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Parish> Parishes { get; set; }
    }
}
