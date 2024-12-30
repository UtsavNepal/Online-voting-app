using Microsoft.EntityFrameworkCore;
using OnlineVotingApp.API.Models;
using System.Collections.Generic;

namespace OnlineVotingApp.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Candidate)
                .WithMany() // Assuming one candidate can have many votes
                .HasForeignKey(v => v.CandidateId)
                .OnDelete(DeleteBehavior.Cascade); // Optional: choose the delete behavior
        }
    }

}
