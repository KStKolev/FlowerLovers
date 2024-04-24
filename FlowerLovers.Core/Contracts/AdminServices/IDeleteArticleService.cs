namespace FlowerLovers.Core.Contracts.AdminServices
{
    public interface IDeleteArticleService
    {
        public Task DeleteArticle(int articleId);
    }
}
