namespace FlowerLovers.Core.Contracts.ArticleServices
{
    public interface ISaveArticleService
    {
        public Task SaveArticle(int articleId, string userId);
    }
}
