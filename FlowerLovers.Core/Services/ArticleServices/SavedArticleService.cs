using FlowerLovers.Core.Contracts.ArticleServices;
using FlowerLovers.Core.CustomExceptions;
using FlowerLovers.Core.Services.ArticleServices.Models;
using FlowerLovers.Data.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace FlowerLovers.Core.Services.ArticleServices
{
    public class SavedArticleService : ISavedArticleService
    {
        private readonly FlowerLoversDbContext data;

        public SavedArticleService(FlowerLoversDbContext _data) 
        {
            data = _data;
        }

        public async Task<IEnumerable<ArticleModel>> SavedArticles(string userId)
        {
            if (userId == null)
            {
                throw new ArgumentException(nameof(userId));
            }

            var user = await data.Users.FindAsync(userId);

            if (user == null) 
            {
                throw new UserNullException(nameof(user));
            }

            var userAccount = await data
                .UserAccounts
                .FirstOrDefaultAsync(ua => ua.Username == user.UserName);

            if (userAccount == null) 
            {
                throw new UserAccountNullException(nameof(userAccount));
            }

            var articlesParticipants = await data
                .ArticlesParticipants
                .Where(ap => ap.UserAccountId == userAccount.Id)
                .Select(ap => new ArticleModel
                (
                    ap.ArticleId,
                    ap.Article.Title,
                    ap.UserAccount.Username,
                    ap.UserAccount.ImageUrl,
                    ap.Article.ImageUrl,
                    ap.Article.Content
                ))
                .ToListAsync();

            return articlesParticipants;
        }
    }
}
