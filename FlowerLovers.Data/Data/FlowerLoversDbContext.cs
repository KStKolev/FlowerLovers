﻿using FlowerLovers.Data.Data.Models;
using Microsoft.AspNetCore.Identity;
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
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Rate> Rates { get; set; } = null!;
        public DbSet<ArticleParticipant> ArticlesParticipants { get; set; } = null!;

        private ApplicationUser AdminUser { get; set; } = null!;
        private Category AmusementCategory { get; set; } = null!;
        private Category EducationalCategory { get; set; } = null!;
        private Category AppealCategory { get; set; } = null!;

        private void SeedApplicationUser() 
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            AdminUser = new ApplicationUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "admin@mail.com",
                NormalizedUserName = "admin@mail.com",
                Email = "admin@mail.com",
                NormalizedEmail = "admin@mail.com",
                FirstName = "Kolio",
                LastName = "Kolev"
            };
            AdminUser.PasswordHash = hasher.HashPassword(AdminUser, "admin123");
        }

        private void SeedCategory() 
        {
            AmusementCategory = new Category()
            {
                Id = 1,
                Name = "Amusement"
            };

            EducationalCategory = new Category()
            {
                Id = 2,
                Name = "Educational"
            };

            AppealCategory = new Category()
            {
                Id = 3,
                Name = "Appeal"
            };
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


            //Seed Categories
            SeedCategory();
            builder.Entity<Category>()
                .HasData(
                AmusementCategory, 
                EducationalCategory, 
                AppealCategory);

            //Seed Application Users
            SeedApplicationUser();
            builder.Entity<ApplicationUser>()
                .HasData(AdminUser);

            base.OnModelCreating(builder);
        }
    }
}
