using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;
using System.Security.Cryptography;
using System.Text;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // 🧩 GET: api/user
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // 🧩 POST: api/user
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }

        // 🧩 POST: api/user/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
                return Unauthorized("Invalid email or password.");

            // Compare hashed password
            var hash = Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(request.Password)));
            if (user.PasswordHash != hash)
                return Unauthorized("Invalid email or password.");

            return Ok(new
            {
                user.Id,
                user.FirstName,
                user.LastName,
                user.Email
            });
        }

        // 🧩 POST: api/user/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User newUser)
        {
            // Check if email already exists
            if (await _context.Users.AnyAsync(u => u.Email == newUser.Email))
                return BadRequest("Email already registered.");

            // Hash password before saving
            newUser.PasswordHash = Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(newUser.PasswordHash)));

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                newUser.Id,
                newUser.FirstName,
                newUser.LastName,
                newUser.Email
            });
        }
    }
}
