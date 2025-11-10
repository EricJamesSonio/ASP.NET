namespace MyApp.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Party { get; set; }

        // Image URL for frontend display
        public string? ImageUrl { get; set; }

        // Navigation property for votes
        public List<Vote> Votes { get; set; } = new();
    }
}
