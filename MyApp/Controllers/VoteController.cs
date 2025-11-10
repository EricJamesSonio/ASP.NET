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

        // POST /api/vote
        [HttpPost]
        public async Task<ActionResult> CastVote(int userId, int candidateId)
        {
            var user = await _context.Users.FindAsync(userId);
            var candidate = await _context.Candidates.FindAsync(candidateId);

            if (user == null || candidate == null)
                return NotFound("User or Candidate not found");

            if (await _context.Votes.AnyAsync(v => v.UserId == userId))
                return BadRequest("User has already voted");

            var vote = new Vote
            {
                UserId = userId,
                CandidateId = candidateId
            };

            _context.Votes.Add(vote);
            await _context.SaveChangesAsync();

            // Return a minimal object to avoid cycles
            return Ok(new 
            {
                voteId = vote.Id,
                userId = vote.UserId,
                candidateId = vote.CandidateId,
                votedAt = vote.VotedAt
            });
        }

        // GET /api/vote/results
        [HttpGet("results")]
        public async Task<ActionResult> GetResults()
        {
            var results = await _context.Candidates
                .Select(c => new
                {
                    candidate = c.Name,
                    votes = c.Votes.Count
                })
                .ToListAsync();

            return Ok(results);
        }
    }
}
