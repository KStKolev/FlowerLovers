using FlowerLovers.Core.Services.ArticleServices.Models;

namespace FlowerLovers.Core.Contracts.ArticleServices
{
    public interface IDetailsArticleService
    {
        public Task<DetailsArticleModel> GetDetailsArticle(int articleId);
    }
}
