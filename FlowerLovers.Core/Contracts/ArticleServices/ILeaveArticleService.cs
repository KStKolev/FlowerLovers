namespace FlowerLovers.Core.Contracts.ArticleServices
{
    public interface ILeaveArticleService
    {
        public Task LeaveSaved(int articleId, string userId);
    }
}
