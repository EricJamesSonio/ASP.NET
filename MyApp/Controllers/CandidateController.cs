using Microsoft.AspNetCore.Mvc;
using MyApp.Data;
using MyApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CandidateController(AppDbContext context)
        {
            _context = context;
        }

        // GET /api/candidate
        [HttpGet]
        public async Task<ActionResult<List<CandidateDto>>> GetCandidates()
        {
            var candidates = await _context.Candidates
                .Select(c => new CandidateDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Party = c.Party,
                    VoteCount = c.Votes.Count
                })
                .ToListAsync();

            return Ok(candidates);
        }

        // POST /api/candidate
        [HttpPost]
        public async Task<ActionResult<Candidate>> CreateCandidate(Candidate candidate)
        {
            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCandidates), new { id = candidate.Id }, candidate);
        }
    }
}
