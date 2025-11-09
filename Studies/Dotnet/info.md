program.cs = acts like the server main when runs define what 
data - dbcontext defines what tables to put in the database
models - defines the fields in that table example in user table we define name, id etc.
controller have this :
using Microsoft.AspNetCore.Mvc;
using MyApp.Data;   - lcoation of the dbcontext
using MyApp.Models; - location of the database trables

was use for built in api! the httpget, httppost, api controller  and controlelr base for builfin api