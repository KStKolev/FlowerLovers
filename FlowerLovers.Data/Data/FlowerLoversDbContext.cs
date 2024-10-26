using FlowerLovers.Data.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace FlowerLovers.Data.Data
{
    public class FlowerLoversDbContext : IdentityDbContext<ApplicationUser>
    {
        public FlowerLoversDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserAccount> UserAccounts { get; set; } = null!;
        public DbSet<Article> Articles { get; set; } = null!;
        public DbSet<Rate> Rates { get; set; } = null!;
        public DbSet<ArticleParticipant> ArticlesParticipants { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "FlowerLoversDb");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Sets primary keys for the data model
            builder
                .Entity<ArticleParticipant>()
                .HasKey(k => new 
            {
                k.ArticleId, 
                k.UserAccountId
            });

            // One-To-Many relationship
            builder
                .Entity<Article>()
                .HasOne(a => a.UserAccount)
                .WithMany(ua => ua.Articles)
                .OnDelete(DeleteBehavior.Restrict);

            // One-To-Many relationship
            builder.Entity<Rate>()
                .HasOne(r => r.Article)
                .WithMany(a => a.Rates)
                .OnDelete(DeleteBehavior.Restrict);

            // Realization of Many-To-Many relationship
            builder
                .Entity<ArticleParticipant>()
                .HasOne(a => a.Article)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<ArticleParticipant>()
                .HasOne(a => a.UserAccount)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
