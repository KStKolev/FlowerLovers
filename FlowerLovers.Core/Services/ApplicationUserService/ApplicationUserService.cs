using FlowerLovers.Core.CustomExceptions;
using FlowerLovers.Data.Data;
using static FlowerLovers.Core.CustomExceptions.DataConstants.UserDataConstants;
using static FlowerLovers.Core.CustomExceptions.DataConstants.NameDataConstants;
using FlowerLovers.Core.Contracts.ApplicationServices;

namespace FlowerLovers.Core.Services.ApplicationUserService
{
    public class ApplicationUserService : IApplicationServiceUser
    {
            private readonly FlowerLoversDbContext data;

            public ApplicationUserService(FlowerLoversDbContext _data)
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
                    throw new UserNullException(USER_NULL_MESSAGE);
                }

                if (string.IsNullOrEmpty(user.FirstName)
                    ||
                    string.IsNullOrEmpty(user.LastName)
                    )
                {
                    // Create a custom exception.
                    throw new NameNullOrEmptyException(NAME_ERROR_MESSAGE);
                }

                return user.FirstName + " " + user.LastName;
            }
    }
}
