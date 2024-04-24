using FlowerLovers.Core.Contracts.ArticleServices;
using FlowerLovers.Core.CustomExceptions;
using FlowerLovers.Core.CustomExceptions.DataConstants;
using FlowerLovers.Data.Data;
using FlowerLovers.Data.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FlowerLovers.Core.Services.ArticleServices
{
    public class LeaveArticleService : ILeaveArticleService
    {
        private FlowerLoversDbContext data;

        public LeaveArticleService(FlowerLoversDbContext _data)
        {
            data = _data;
        }

        public async Task LeaveSaved(int articleId, string userId)
        {
            if (userId == null)
            {
                throw new ArgumentException(nameof(userId));
            }

            var articleToRemove = await data
                .Articles
                .FindAsync(articleId);

            if (articleToRemove == null)
            {
                throw new ArticleNullException(ArticleDataConstants.ARTICLE_ERROR_MESSAGE);
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

            var articleParticipantToRemove = new ArticleParticipant() 
            {
                ArticleId = articleId,
                UserAccountId = userAccount.Id,
                Article = articleToRemove,
                UserAccount = userAccount,
            };

            if (await data.ArticlesParticipants.ContainsAsync(articleParticipantToRemove))
            {
                data.ArticlesParticipants.Remove(articleParticipantToRemove);
                await data.SaveChangesAsync();
            }
        }
    }
}
