Seeding new tables in database/ creating: 

dotnet ef migrations add VotingSystemInitial

dotnet ef database update


required to activate sqagger open api:
// used for testing! 

dotnet add package Swashbuckle.AspNetCore

visit this for testing...
http://localhost:5192/swagger/index.html
