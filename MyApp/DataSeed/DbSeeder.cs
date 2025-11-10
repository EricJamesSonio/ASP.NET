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
                    new() { Name = "Alice Johnson", Party = "Unity Party" },
                    new() { Name = "Bob Martinez", Party = "People's Voice" },
                    new() { Name = "Clara Lim", Party = "Forward Together" },
                    new() { Name = "David Cruz", Party = "National Front" },
                    new() { Name = "Ella Reyes", Party = "Reform Alliance" },
                    new() { Name = "Francis Tan", Party = "Progressive Group" },
                    new() { Name = "Grace Lee", Party = "People First" },
                    new() { Name = "Henry Bautista", Party = "Future Now" },
                    new() { Name = "Ivy Santos", Party = "Justice League" },
                    new() { Name = "Jacob dela Cruz", Party = "Renewal Party" },
                    new() { Name = "Karla Mendoza", Party = "Citizen's Voice" },
                    new() { Name = "Leo Ramos", Party = "Forward Nation" },
                    new() { Name = "Mia Navarro", Party = "People’s Unity" },
                    new() { Name = "Nathan Ong", Party = "Vision 2025" },
                    new() { Name = "Olivia Flores", Party = "National Reform" },
                    new() { Name = "Patrick Chua", Party = "Hope Party" },
                    new() { Name = "Queenie Delgado", Party = "Progress Party" },
                    new() { Name = "Rafael Santos", Party = "One Nation" },
                    new() { Name = "Sofia Cruz", Party = "People Power" },
                    new() { Name = "Tomas Villanueva", Party = "New Dawn" }
                };

                context.Candidates.AddRange(candidates);
                context.SaveChanges();
            }
        }
    }
}
