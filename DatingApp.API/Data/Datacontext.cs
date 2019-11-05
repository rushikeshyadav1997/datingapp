using DatingApp.API.models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class Datacontext:DbContext 
    {
      public Datacontext(DbContextOptions<Datacontext>options):base(options){}
      public DbSet<value> Values { get; set; }  
      public DbSet<user> Users {get;set;}
      public DbSet<Photo> Photos{get;set;}
    }
}