using Amber_HealthAPI.Data;
using Amber_HealthAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Amber_HealthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BookingDbContext _dbContext;

        public BookingController(BookingDbContext dbContext) => _dbContext = dbContext;

        //Get all Booking
        [HttpGet]
        public IActionResult GetAllBooking()
        {
            try
            {
                var pBookings = _dbContext.Bookings.Include(b => b.Profession).Include(b => b.Parish).Include(b => b.Contact).ToList();
                if (pBookings == null)
                {
                    return BadRequest();
                }
                return Ok(pBookings);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }



        }
        //Get Booking by Id
        [HttpGet("{id}")]
        public IActionResult GetBookingById(int id)
        {
            try
            {
                var pBookings = _dbContext.Bookings.Include(b => b.Profession).Include(b => b.Parish).Include(b => b.Contact).FirstOrDefault(x => x.Id == id);
                if (pBookings == null)
                {
                    return NotFound($"Booking details not found with Id {id}");
                }
                return Ok(pBookings);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        //Post Booking details
        [HttpPost]
        public IActionResult PostBooking(Booking model)
        {
            try
            {
                _dbContext.Add(model);
                _dbContext.SaveChanges();
                return Ok("Booking Details created.");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        //Update Booking Details
        [HttpPut]
        public IActionResult PutBooking(Booking model)
        {


            if (model == null || model.Id == 0)
            {
                if (model == null)
                {
                    return BadRequest("Model data is invalid.");
                }
                else if (model.Id == 0)
                {
                    return BadRequest($"Booking Id {model.Id} is invalid");
                }
            }
            try
            {
                var pBookings = _dbContext.Bookings.Include(b => b.Profession).Include(b => b.Parish).Include(b => b.Contact).
                    FirstOrDefault(x => x.Id == model.Id);
                if (pBookings == null)
                {
                    return NotFound($"Booking not found with id {model.Id}");
                }
                pBookings.FirstName = model.FirstName;
                pBookings.LastName = model.LastName;
                pBookings.Email = model.Email;
                pBookings.Contact = model.Contact;
                pBookings.Parish = model.Parish;
                pBookings.Profession = model.Profession;
                pBookings.ContactId = model.ContactId;
                pBookings.ProfessionId = model.ProfessionId;
                pBookings.ParishId = model.ParishId;
               
                _dbContext.Update(pBookings);
                _dbContext.SaveChanges();
                return Ok("Booking details updated.");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        //Delete Booking details
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingByIdAsync(int id)
        {
            try
            {
                var pBookings = await _dbContext.Bookings.FindAsync(id);
                if (pBookings == null)
                {
                    return NotFound($"Booking not found with id {id}");
                }
                _dbContext.Remove(pBookings);
                _dbContext.SaveChanges();
                return Ok("Booking details deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpGet]
        [Route("Contact")]
        public IActionResult GetContact()
        {
            try
            {
                var pContact = _dbContext.Contacts.ToList();
                if (pContact == null)
                {
                    return BadRequest();
                }
                return Ok(pContact);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("Profession")]
        public IActionResult GetProfession()
        {
            try
            {
                var pProfession = _dbContext.Professions.ToList();
                if (pProfession == null)
                {
                    return BadRequest();
                }
                return Ok(pProfession);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("Parish")]
        public IActionResult GetParishes()
        {
            try
            {
                var pParishes = _dbContext.Parishes.ToList();
                if (pParishes == null)
                {
                    return BadRequest();
                }
                return Ok(pParishes);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
