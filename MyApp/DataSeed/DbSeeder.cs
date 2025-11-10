using MyApp.Models;
using MyApp.Data;

namespace MyApp.DataSeed
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Candidates.Any())
            {
                var candidates = new List<Candidate>
                {
                    new() { Name = "Alice Johnson", Party = "Unity Party", ImageUrl = "https://i.pravatar.cc/150?img=1" },
                    new() { Name = "Bob Martinez", Party = "People's Voice", ImageUrl = "https://i.pravatar.cc/150?img=2" },
                    new() { Name = "Clara Lim", Party = "Forward Together", ImageUrl = "https://i.pravatar.cc/150?img=3" },
                    new() { Name = "David Cruz", Party = "National Front", ImageUrl = "https://i.pravatar.cc/150?img=4" },
                    new() { Name = "Ella Reyes", Party = "Reform Alliance", ImageUrl = "https://i.pravatar.cc/150?img=5" },
                    new() { Name = "Francis Tan", Party = "Progressive Group", ImageUrl = "https://i.pravatar.cc/150?img=6" },
                    new() { Name = "Grace Lee", Party = "People First", ImageUrl = "https://i.pravatar.cc/150?img=7" },
                    new() { Name = "Henry Bautista", Party = "Future Now", ImageUrl = "https://i.pravatar.cc/150?img=8" },
                    new() { Name = "Ivy Santos", Party = "Justice League", ImageUrl = "https://i.pravatar.cc/150?img=9" },
                    new() { Name = "Jacob dela Cruz", Party = "Renewal Party", ImageUrl = "https://i.pravatar.cc/150?img=10" },
                    new() { Name = "Karla Mendoza", Party = "Citizen's Voice", ImageUrl = "https://i.pravatar.cc/150?img=11" },
                    new() { Name = "Leo Ramos", Party = "Forward Nation", ImageUrl = "https://i.pravatar.cc/150?img=12" },
                    new() { Name = "Mia Navarro", Party = "People’s Unity", ImageUrl = "https://i.pravatar.cc/150?img=13" },
                    new() { Name = "Nathan Ong", Party = "Vision 2025", ImageUrl = "https://i.pravatar.cc/150?img=14" },
                    new() { Name = "Olivia Flores", Party = "National Reform", ImageUrl = "https://i.pravatar.cc/150?img=15" },
                    new() { Name = "Patrick Chua", Party = "Hope Party", ImageUrl = "https://i.pravatar.cc/150?img=16" },
                    new() { Name = "Queenie Delgado", Party = "Progress Party", ImageUrl = "https://i.pravatar.cc/150?img=17" },
                    new() { Name = "Rafael Santos", Party = "One Nation", ImageUrl = "https://i.pravatar.cc/150?img=18" },
                    new() { Name = "Sofia Cruz", Party = "People Power", ImageUrl = "https://i.pravatar.cc/150?img=19" },
                    new() { Name = "Tomas Villanueva", Party = "New Dawn", ImageUrl = "https://i.pravatar.cc/150?img=20" }
                };

                context.Candidates.AddRange(candidates);
                context.SaveChanges();
            }
        }
    }
}
