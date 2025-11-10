using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Election> Elections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // no seed here — keep clean
        }
    }
}
