using FlowerLovers.Core.Contracts.ArticleServices;
using FlowerLovers.Core.CustomExceptions;
using FlowerLovers.Core.CustomExceptions.DataConstants;
using FlowerLovers.Core.Services.ArticleServices.Models;
using FlowerLovers.Data.Data;
using FlowerLovers.Data.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FlowerLovers.Core.Services.ArticleServices
{
    public class RateService : IRateService
    {
        private readonly FlowerLoversDbContext data;

        public RateService(FlowerLoversDbContext _data)
        {
            data = _data;
        }

        public async Task RateArticle(RateModel model, int articleId, string userId)
        {
            var isFalseArticleId = await data
                .Articles
                .AnyAsync(a => a.Id == articleId);

            if (isFalseArticleId == false)
            {
                throw new ArgumentException(nameof(articleId));
            }

            if (userId == null)
            {
                throw new ArgumentException(nameof(userId));
            }

            var user = await data
                .Users
                .FindAsync(userId);

            if (user == null)
            {
                throw new UserNullException(UserDataConstants.USER_NULL_MESSAGE);
            }

            var userAccount = await data
                .UserAccounts
                .FirstOrDefaultAsync(ua => ua.Username == user.UserName);

            if (userAccount == null) 
            {
                throw new UserAccountNullException(UserAccountDataConstants.USER_ACCOUNT_ERROR_MESSAGE);
            }

            var rateToAdd = new Rate()
            {
                ArticleId = articleId,
                UserAccountId = userAccount.Id,
                Rating = model.Rating
            };

            var rateContained = await data
                .Rates
                .FirstOrDefaultAsync(r => r.ArticleId == articleId && r.UserAccountId == userAccount.Id);

            if (rateContained != null)
            {
                rateContained.Rating = model.Rating;
            }
            else 
            {
                await data.Rates.AddAsync(rateToAdd);
            }
            await data.SaveChangesAsync();
        }
    }
}
