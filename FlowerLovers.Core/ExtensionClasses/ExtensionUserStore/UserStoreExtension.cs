using FlowerLovers.Data.Data.Models;

namespace Microsoft.AspNetCore.Identity
{
    public static class UserStoreExtension
    {
        public static void SetUserNames(
            ApplicationUser user, 
            string firstName, 
            string lastName) 
        {
            if (user == null || firstName == null || lastName == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            user.FirstName = firstName;
            user.LastName = lastName;
        }
    }
}
