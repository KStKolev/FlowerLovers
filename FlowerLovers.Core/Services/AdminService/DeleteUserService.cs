using FlowerLovers.Core.Contracts.AdminServices;
using FlowerLovers.Core.CustomExceptions;
using FlowerLovers.Core.CustomExceptions.DataConstants;
using FlowerLovers.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace FlowerLovers.Core.Services.AdminService
{
    public class DeleteUserService : IDeleteUserService
    {
        private readonly FlowerLoversDbContext data;

        public DeleteUserService(FlowerLoversDbContext _data)
        {
            data = _data;
        }

        public async Task DeleteUser(int userAccountId)
        {

            var userAccount = await data
                .UserAccounts
                .FirstOrDefaultAsync(ua => ua.Id == userAccountId);

            if (userAccount == null) 
            {
                throw new UserAccountNullException(UserAccountDataConstants.USER_ACCOUNT_ERROR_MESSAGE);
            }

            var articles = await data
                .Articles
                .Where(a => a.UserAccountId == userAccount.Id)
                .ToListAsync();

            if (articles != null && articles.Count() > 0)
            {
                foreach (var article in articles)
                {
                    var articleParticipants = await data
                    .ArticlesParticipants
                    .Where(ap => ap.ArticleId == article.Id)
                    .ToListAsync();

                    if (articleParticipants != null && articleParticipants.Count() > 0)
                    {
                        data.ArticlesParticipants.RemoveRange(articleParticipants);
                    }

                    var rates = await data
                        .Rates
                        .Where(r => r.ArticleId == article.Id)
                        .ToListAsync();

                    if (rates != null && rates.Count() > 0)
                    {
                        data.Rates.RemoveRange(rates);
                    }
                }
                data.Articles.RemoveRange(articles);
            }

            var user = await data
                .Users
                .FirstOrDefaultAsync(u => u.UserName == userAccount.Username);

            if (user == null)
            {
                throw new UserNullException(nameof(user));
            }

            data.UserAccounts.Remove(userAccount);
            data.Users.Remove(user);
            await data.SaveChangesAsync();
        }
    }
}
