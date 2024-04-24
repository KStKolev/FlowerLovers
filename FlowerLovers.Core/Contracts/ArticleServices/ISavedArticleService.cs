using FlowerLovers.Core.Services.ArticleServices.Models;

namespace FlowerLovers.Core.Contracts.ArticleServices
{
    public interface ISavedArticleService
    {
        public Task<ArticleModel> SavedArticles(string userId, int currentPage, int articlesPerPage);
    }
}
