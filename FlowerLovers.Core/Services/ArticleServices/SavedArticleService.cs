using FlowerLovers.Core.Contracts.ArticleServices;
using FlowerLovers.Core.CustomExceptions;
using FlowerLovers.Core.CustomExceptions.DataConstants;
using FlowerLovers.Core.Services.ArticleServices.Models;
using FlowerLovers.Data.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public async Task<ArticleModel> SavedArticles(string userId, int currentPage, int articlesPerPage)
        {
            if (userId == null)
            {
                throw new ArgumentException(nameof(userId));
            }

            var user = await data
                .Users
                .FindAsync(userId);

            if (user == null) 
            {
                throw new UserNullException(UserDataConstants.USER_NULL_MESSAGE);
            }

            var userAccount = await data
                .UserAccounts
                .FirstOrDefaultAsync(ua => ua.Username == user.UserName);

            if (userAccount == null) 
            {
                throw new UserAccountNullException(UserAccountDataConstants.USER_ACCOUNT_ERROR_MESSAGE);
            }

            var articleIds = await 
                data
                .ArticlesParticipants
                .Where(ap => ap.UserAccountId == userAccount.Id)
                .Select(ap => ap.ArticleId)
                .ToListAsync();

            var articles = await data.Articles
           .Where(a => articleIds.Contains(a.Id))
           .Skip((currentPage - 1) * articlesPerPage)
           .Take(articlesPerPage)
           .ToListAsync();

            var totalItems = articleIds.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)articlesPerPage);

            ArticleModel model = new ArticleModel
            {
                Articles = articles,
                TotalPages = totalPages,
                CurrentPage = currentPage,
            };

            return model;
        }
    }
}
