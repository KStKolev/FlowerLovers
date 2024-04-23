using FlowerLovers.Core.Contracts.AccountService;
using FlowerLovers.Data.Data;
using FlowerLovers.Data.Data.Models;
using Microsoft.EntityFrameworkCore;
using FlowerLovers.Core.Services.AccountServices.Models.DataRequirements;
using System.Globalization;

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
            var user = await data.Users.FindAsync(userId);

            if (user == null)
            {
                // Create a custom message
                throw new ArgumentException();
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

            return userAccount;
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
