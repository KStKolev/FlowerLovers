using FlowerLovers.Core.Services.ArticleServices.Models;

namespace FlowerLovers.Core.Contracts.ArticleServices
{
    public interface ISavedArticleService
    {
        public Task<IEnumerable<ArticleModel>> SavedArticles(string userId);
    }
}
