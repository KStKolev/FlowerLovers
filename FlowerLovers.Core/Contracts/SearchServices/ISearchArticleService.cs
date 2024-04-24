using FlowerLovers.Core.Services.ArticleServices.Models;

namespace FlowerLovers.Core.Contracts.SearchServices
{
    public interface ISearchArticleService
    {
        public Task<ArticleModel> SearchArticle(string articleName, int currentPage, int articlesPerPage);
    }
}
