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

        // ✅ GET all users
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // ✅ Register user
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User newUser)
        {
            // Check email exists
            if (await _context.Users.AnyAsync(u => u.Email == newUser.Email))
                return BadRequest("Email already registered.");

            // Default role
            newUser.Role = newUser.Role ?? "Voter";

            // Hash password
            newUser.PasswordHash = Convert.ToBase64String(
                SHA256.HashData(Encoding.UTF8.GetBytes(newUser.PasswordHash))
            );

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            var response = new UserResponse
            {
                Id = newUser.Id,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                Role = newUser.Role
            };

            return Ok(response);
        }

        // ✅ LOGIN
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null) return Unauthorized("Invalid email or password.");

            // Compare hash
            var hash = Convert.ToBase64String(
                SHA256.HashData(Encoding.UTF8.GetBytes(request.Password))
            );

            if (user.PasswordHash != hash)
                return Unauthorized("Invalid email or password.");

            var response = new UserResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role
            };

            return Ok(response);
        }
    }
}
