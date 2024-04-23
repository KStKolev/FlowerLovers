using FlowerLovers.Core.Services.ArticleServices.Models;

namespace FlowerLovers.Core.Contracts.ArticleServices
{
    public interface IAddArticleService
    {
        public Task AddArticle(string userId, AddArticleModel model);
    }
}
