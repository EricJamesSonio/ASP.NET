namespace MyApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        
        // For login
        public string PasswordHash { get; set; } = null!;
        
        // Optional role
        public string? Role { get; set; }
    }
}
