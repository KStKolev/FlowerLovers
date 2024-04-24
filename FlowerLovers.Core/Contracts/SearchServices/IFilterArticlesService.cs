using FlowerLovers.Core.Services.ArticleServices.Models;

namespace FlowerLovers.Core.Contracts.SearchServices
{
    public interface IFilterArticlesService
    {
        public Task<ArticleModel> FilteredArticles(string category, int currentPage, int articlesPerPage);
    }
}
