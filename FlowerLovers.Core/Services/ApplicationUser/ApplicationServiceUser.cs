using FlowerLovers.Core.Contracts;
using FlowerLovers.Core.CustomExceptions;
using FlowerLovers.Data.Data;
using static FlowerLovers.Core.CustomExceptions.DataConstants.UserDataConstants;
using static FlowerLovers.Core.CustomExceptions.DataConstants.NameDataConstants;

namespace FlowerLovers.Core.Services.ApplicationUser
{
    public class ApplicationServiceUser : IApplicationServiceUser
    {
        private readonly FlowerLoversDbContext data;

        public ApplicationServiceUser(FlowerLoversDbContext _data)
        {
            data = _data;
        }

        public async Task<string> UserFullNameAsync(string userId)
        {
            if (userId == null)
            {
                throw new ArgumentNullException(nameof(userId));
            }
            var user = await data.Users.FindAsync(userId);

            if (user == null)
            {
                throw new UserNullException(USERNULLMESSAGE);
            }

            if (string.IsNullOrEmpty(user.FirstName)
                ||
                string.IsNullOrEmpty(user.LastName)
                )
            {
                // Create a custom exception.
                throw new NameNullOrEmptyException(NAMEERRORMESSAGE);
            }

            return user.FirstName + " " + user.LastName;
        }
    }
}
