using FlowerLovers.Core.Contracts.ArticleServices;
using FlowerLovers.Core.CustomExceptions;
using FlowerLovers.Core.Services.ArticleServices.Models;
using FlowerLovers.Data.Data;
using FlowerLovers.Data.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FlowerLovers.Core.Services.ArticleServices
{
    public class DetailsArticleService : IDetailsArticleService
    {
        private readonly FlowerLoversDbContext data;

        public DetailsArticleService(FlowerLoversDbContext _data) 
        {
            data = _data;
        }

        public async Task<DetailsArticleModel> GetDetailsArticle(int articleId)
        {
            var article = await data
                .Articles
                .FindAsync(articleId);

            if (article == null) 
            {
                throw new ArticleNullException(nameof(articleId));
            }

            //Get every rate from the current article.
            var ratesOfArticle = await data
                .Rates
                .Where(r => r.ArticleId == articleId)
                .ToListAsync();

            var detailsArticle = await data
                .Articles
                .Where(a => a.Id == articleId)
                .Select(a => new DetailsArticleModel
                (
                    a.Id,
                    a.Title,
                    a.UserAccount.Username,
                    a.UserAccount.ImageUrl,
                    a.ImageUrl,
                    a.Content,
                    a.DateOfPublish,
                    GetAverageRate(ratesOfArticle)
                ))
                .FirstOrDefaultAsync();

            if (detailsArticle == null)
            {
                throw new DetailsArticleNullException(nameof(detailsArticle));
            }

            return detailsArticle;
        }

        private double GetAverageRate(IEnumerable<Rate> rates) 
        {
            double result = 0;
            foreach (var rate in rates)
            {
                result += rate.Rating;
            }

            if (result != 0)
            {
                result /= rates.Count();
            }

            return result;
        }
    }
}
