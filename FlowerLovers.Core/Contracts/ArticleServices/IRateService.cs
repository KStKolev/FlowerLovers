using FlowerLovers.Core.Services.ArticleServices.Models;

namespace FlowerLovers.Core.Contracts.ArticleServices
{
    public interface IRateService
    {
        public Task RateArticle(RateModel model, int articleId, string userId);
    }
}
