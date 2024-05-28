using LearnAngular.API.Data;
using LearnAngular.API.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnAngular.API.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class HotelsController : Controller
    {
        private readonly HotelsDbContext hotelsDbContext;

        public HotelsController(HotelsDbContext hotelsDbContext)
        {
            this.hotelsDbContext = hotelsDbContext;
        }

        //GetAll hotels
        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            var hotels = await hotelsDbContext.Hotels.ToListAsync();
            return Ok(hotels);
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("{id:guid}")]
        [ActionName("GetHotel")]
        public async Task<IActionResult> GetHotel([FromRoute] Guid id)
        {
            var hotels = await hotelsDbContext.Hotels.FirstOrDefaultAsync(x => x.Id == id);
            if(hotels != null)
            {
                return Ok(hotels);
            }
            return NotFound("Not Found Hotel");

        }

        [HttpPost]
        public async Task<IActionResult> AddHotels([FromBody] Hotel hotel)
        {
            hotel.Id = Guid.NewGuid(); 
            await hotelsDbContext.Hotels.AddAsync(hotel);
            await hotelsDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHotel), new { id = hotel.Id }, hotel);
        }

        [HttpPut]
        [Microsoft.AspNetCore.Mvc.Route("{id:guid}")]
        public async Task<IActionResult> UpdateHotel([FromRoute] Guid id, [FromBody] Hotel hotel)
        {
            var existinghotels = await hotelsDbContext.Hotels.FirstOrDefaultAsync(x => x.Id == id);
            if(existinghotels != null)
            {
                existinghotels.Id = hotel.Id;
                existinghotels.HotelsName = hotel.HotelsName;
                existinghotels.HotelsAddress = hotel.HotelsAddress;
                existinghotels.City = hotel.City;
                existinghotels.State = hotel.State;
                existinghotels.Phone = hotel.Phone;
                existinghotels.Email = hotel.Email;
                existinghotels.Website = hotel.Website;
                existinghotels.Description = hotel.Description;
                existinghotels.Rating = hotel.Rating;

                await hotelsDbContext.SaveChangesAsync();
                return Ok(existinghotels);
            }
            return NotFound("Hotel Not Fount");
        }

        [HttpDelete]
        [Microsoft.AspNetCore.Mvc.Route("{id:guid}")]
        public async Task<IActionResult> DeleteHotel([FromRoute] Guid id)
        {
            var existinghotels = await hotelsDbContext.Hotels.FirstOrDefaultAsync(x => x.Id == id);
            if (existinghotels != null)
            {
                hotelsDbContext.Remove(existinghotels);
                await hotelsDbContext.SaveChangesAsync();
                return Ok(existinghotels);
            }
            return NotFound("Hotel Not Fount");
        }
    }
}
