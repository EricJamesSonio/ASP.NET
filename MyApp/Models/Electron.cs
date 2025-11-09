namespace MyApp.Models
{
    public class Election
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<Candidate> Candidates { get; set; } = new();
    }
}
