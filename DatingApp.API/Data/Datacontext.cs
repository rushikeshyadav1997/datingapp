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
      public DbSet<Like> Likes{get;set;}
      public DbSet<Message> Messages { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Like>()
                .HasKey(k => new { k.LikerId, k.LikeeId });

            builder.Entity<Like>()
               .HasOne(u => u.Likee)
               .WithMany(u => u.Likers)
               .HasForeignKey(u => u.LikeeId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Like>()
               .HasOne(u => u.Liker)
               .WithMany(u => u.Likees)
               .HasForeignKey(u => u.LikerId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
               .HasOne(u => u.Sender)
               .WithMany(u => u.MessagesSent)
               .OnDelete(DeleteBehavior.Restrict);
            
             builder.Entity<Message>()
               .HasOne(u => u.Recipient)
               .WithMany(u => u.MessagesReceived)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }

}