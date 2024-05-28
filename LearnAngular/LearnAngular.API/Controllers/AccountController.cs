using LearnAngular.API.Data;
using LearnAngular.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace LearnAngular.API.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly HotelsDbContext hotelsDbContext;

        public AccountController(HotelsDbContext hotelsDbContext)
        {
            this.hotelsDbContext = hotelsDbContext;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var userName = await hotelsDbContext.Users
                .FirstOrDefaultAsync(x => x.UserName == user.UserName && x.Password == user.Password);
            if (userName != null)
            {
                return Ok(new
                {
                    Message = "Login Success"
                }); ;
            }
            return NotFound("User Not Found");
        }
        [HttpPost("checklogin")]
        public async Task<IActionResult> CheckLogin([FromBody] User user)
        {
            var userName = await hotelsDbContext.Users
                .FirstOrDefaultAsync(x => x.UserName == user.UserName);
            if (userName == null)
            {
                return Ok(new
                {
                    Message = "Login Success"
                }); ;
            }
            return NotFound("User Not Found");
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] User user)
        {
            var userName = await hotelsDbContext.Users
                .FirstOrDefaultAsync(x => x.UserName == user.UserName);
            if (userName == null)
            {
                user.Id = Guid.NewGuid();
                await hotelsDbContext.Users.AddAsync(user);
                await hotelsDbContext.SaveChangesAsync();

                return CreatedAtAction(nameof(SignUp), new { id = user.Id }, user);
            }
            return NotFound("UserName Already exist");
        }
    }
}
