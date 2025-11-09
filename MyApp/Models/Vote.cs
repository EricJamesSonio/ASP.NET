namespace MyApp.Models
{
    public class Vote
    {
        public int Id { get; set; }

        // Foreign keys
        public int UserId { get; set; }
        public User? User { get; set; }

        public int CandidateId { get; set; }
        public Candidate? Candidate { get; set; }

        public DateTime VotedAt { get; set; } = DateTime.UtcNow;
    }
}
