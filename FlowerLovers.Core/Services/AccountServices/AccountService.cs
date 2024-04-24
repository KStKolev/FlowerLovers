using FlowerLovers.Core.Contracts.AccountService;
using FlowerLovers.Data.Data;
using FlowerLovers.Data.Data.Models;
using Microsoft.EntityFrameworkCore;
using FlowerLovers.Core.Services.AccountServices.Models.DataRequirements;
using System.Globalization;
using FlowerLovers.Core.CustomExceptions;
using FlowerLovers.Core.CustomExceptions.DataConstants;

namespace FlowerLovers.Core.Services.AccountServices
{
    public class AccountService : IAccountService
    {
        private readonly FlowerLoversDbContext data;

        public AccountService(FlowerLoversDbContext _data)
        {
            data = _data;
        }

        public async Task<UserAccount> CreateUserAccount(string userId)
        {
            if (userId == null)
            {
                throw new ArgumentException(nameof(userId));
            }

            var user = await data.Users.FindAsync(userId);

            if (user == null)
            {
                throw new UserAccountNullException(UserAccountDataConstants.USER_ACCOUNT_ERROR_MESSAGE);
            }

            bool isAccountCreated = await data.UserAccounts
                .AnyAsync(ua => ua.Username == user.UserName);

            if (isAccountCreated == false)
            {
                DateTime createAccountDate = FormattedDateOfCreation();

                // Setting the default user account image
                string imagePath = "Content/Images/default-user.png";

                var newUserAccount = new UserAccount()
                {
                    Username = user.UserName,
                    ImageUrl = imagePath,
                    Biography = string.Empty,
                    CreationDate = createAccountDate
                };

                await data
                    .UserAccounts
                    .AddAsync(newUserAccount);

                await data
                    .SaveChangesAsync();

                return newUserAccount;
            }

            var userAccount = await data
                .UserAccounts
                .FirstAsync(ua => ua.Username == user.UserName);

            var articles = await data
                .Articles
                .Where(a => a.UserAccountId == userAccount.Id)
                .ToListAsync();

            if (articles.Count() > 0)
            {
                userAccount.Articles = articles;
            }

            return userAccount;
        }

        public async Task<UserAccount> CreateUserAccount(int userAccountId, string userId)
        {
            var userAccount = await data
                .UserAccounts
                .FindAsync(userAccountId);

            if (userAccount != null) 
            {
                var articles = await data
                    .Articles
                    .Where(a => a.UserAccountId == userAccount.Id)
                    .ToListAsync();

                userAccount.Articles = articles;

                return userAccount;
            }

            if (userId == null)
            {
                throw new ArgumentException(nameof(userId));
            }

            return await CreateUserAccount(userId);
        }

        // Set the date of creation to dd/MM/yyyy format.
        private DateTime FormattedDateOfCreation()
        {
            DateTime dateNow = DateTime.Now;
            string textDate = dateNow.ToString(DateFormatConstants.DATEFORMAT);
            DateTime createAccountDate = DateTime.ParseExact(textDate, DateFormatConstants.DATEFORMAT, CultureInfo.InvariantCulture);
            return createAccountDate;
        }
    }
}
