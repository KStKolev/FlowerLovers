using FlowerLovers.Core.Services.ArticleServices.Models;

namespace FlowerLovers.Core.Contracts.ArticleServices
{
    public interface IEditArticleService
    {
        public Task<EditArticleModel> GetArticle(int articleId, string userId);

        public Task EditArticle(EditArticleModel model, int articleId);
    }
}
