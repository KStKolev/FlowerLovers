using FlowerLovers.Core.Contracts.ArticleServices;
using FlowerLovers.Core.CustomExceptions;
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
                throw new ArticleNullException(nameof(articleToRemove));
            }

            var user = await data
                .Users
                .FindAsync(userId);

            if (user == null) 
            {
                throw new UserNullException(nameof(user));
            }

            var userAccount = await data
                .UserAccounts
                .FirstOrDefaultAsync(ua => ua.Username == user.UserName);

            if (userAccount == null) 
            {
                throw new UserAccountNullException(nameof(userAccount));
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
