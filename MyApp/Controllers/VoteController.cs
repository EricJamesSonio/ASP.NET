using Microsoft.AspNetCore.Mvc;
using MyApp.Data;
using MyApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VoteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Vote>> CastVote(int userId, int candidateId)
        {
            // Check if user and candidate exist
            var user = await _context.Users.FindAsync(userId);
            var candidate = await _context.Candidates.FindAsync(candidateId);

            if (user == null || candidate == null)
                return NotFound("User or Candidate not found");

            // Optional: prevent double voting (one vote per user)
            if (await _context.Votes.AnyAsync(v => v.UserId == userId))
                return BadRequest("User has already voted");

            var vote = new Vote
            {
                UserId = userId,
                CandidateId = candidateId
            };

            _context.Votes.Add(vote);
            await _context.SaveChangesAsync();
            return Ok(vote);
        }

        [HttpGet("results")]
        public async Task<ActionResult> GetResults()
        {
            var results = await _context.Candidates
                .Include(c => c.Votes)
                .Select(c => new
                {
                    Candidate = c.Name,
                    Votes = c.Votes.Count
                })
                .ToListAsync();

            return Ok(results);
        }
    }
}
