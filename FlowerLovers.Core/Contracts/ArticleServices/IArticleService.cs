using FlowerLovers.Core.Services.ArticleServices.Models;

namespace FlowerLovers.Core.Contracts.ArticleServices
{
    public interface IArticleService
    {
        public Task<ArticleModel> GetArticles(int currentPage, int articlesPerPage);
    }
}
