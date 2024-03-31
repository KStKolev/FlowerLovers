using FlowerLovers.Data.Data.Models;
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
        public DbSet<ArticleTag> ArticlesTags { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Follow> Follows { get; set; } = null!;
        public DbSet<Image> Images { get; set; } = null!;
        public DbSet<Like> Likes { get; set; } = null!;
        public DbSet<Rate> Rates { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;


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
            //One-To-One relationship
            builder.Entity<UserAccount>()
                .HasOne(ua => ua.Image)
                .WithOne(i => i.UserAccount);

            //One-To-One relationship
            builder.Entity<Article>()
                .HasOne(a => a.Image)
                .WithOne(i => i.Article);

            // One-To-Many relationship
            builder
                .Entity<Article>()
                .HasOne(a => a.UserAccount)
                .WithMany(ua => ua.Articles)
                .OnDelete(DeleteBehavior.Restrict);

            // One-To-Many relationship
            builder
                .Entity<Comment>()
                .HasOne(c => c.Article)
                .WithMany(a => a.Comments)
                .OnDelete(DeleteBehavior.Restrict);

            // One-To-Many relationship
            builder.Entity<Comment>()
                .HasOne(c => c.UserAccount)
                .WithMany(ua => ua.Comments)
                .OnDelete(DeleteBehavior.Restrict);

            // One-To-Many relationship
            builder.Entity<Like>()
                .HasOne(l => l.Article)
                .WithMany(a => a.Likes)
                .OnDelete(DeleteBehavior.Restrict);

            // One-To-Many relationship
            builder.Entity<Rate>()
                .HasOne(r => r.Article)
                .WithMany(a => a.Rates)
                .OnDelete(DeleteBehavior.Restrict);

            // Many-To-Many relationship
            builder.Entity<UserAccount>()
                .HasMany(ua => ua.FollowedUserAccount)
                .WithMany(ua => ua.FollowerUserAccount)
                .UsingEntity<Follow>(
                    f => f
                    .HasOne<UserAccount>()
                    .WithMany()
                    .HasForeignKey(f => f.FollowedUserAccountId),
                    f => f
                    .HasOne<UserAccount>()
                    .WithMany()
                    .HasForeignKey(f => f.FollowerUserAccountId)
                );

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

            //Set many-to-many relationship primary keys
            builder
                .Entity<ArticleTag>()
                .HasKey(k => new
                {
                    k.TagId,
                    k.ArticleId
                });

            base.OnModelCreating(builder);
        }
    }
}
