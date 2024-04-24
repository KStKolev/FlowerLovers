using FlowerLovers.Core.Contracts.AdminServices;
using FlowerLovers.Core.CustomExceptions;
using FlowerLovers.Core.CustomExceptions.DataConstants;
using FlowerLovers.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace FlowerLovers.Core.Services.AdminService
{
    public class DeleteArticleService : IDeleteArticleService
    {
        private readonly FlowerLoversDbContext data;

        public DeleteArticleService(FlowerLoversDbContext _data) 
        {
            data = _data;
        }

        public async Task DeleteArticle(int articleId)
        {
            var article = await data
                .Articles
                .FindAsync(articleId);

            if (article == null)
            {
                throw new ArticleNullException(ArticleDataConstants.ARTICLE_ERROR_MESSAGE);
            }

            var articleParticipants = await data
                .ArticlesParticipants
                .Where(ap => ap.ArticleId == articleId)
                .ToListAsync();

            if (articleParticipants != null && articleParticipants.Count() > 0)
            {
                data.ArticlesParticipants.RemoveRange(articleParticipants);
            }

            var rates = await data
                .Rates
                .Where(r => r.ArticleId == articleId)
                .ToListAsync();

            if (rates != null && rates.Count() > 0)
            {
                data.Rates.RemoveRange(rates);
            }

            data.Articles.Remove(article);
            await data.SaveChangesAsync();
        }
    }
}
