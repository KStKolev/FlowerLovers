using FlowerLovers.Core.Contracts.AccountService;
using FlowerLovers.Core.CustomExceptions;
using FlowerLovers.Core.CustomExceptions.DataConstants;
using FlowerLovers.Core.Services.AccountServices.Models;
using FlowerLovers.Data.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace FlowerLovers.Core.Services.AccountServices
{
    public class EditAccountService : IEditAccountService
    {
        private readonly FlowerLoversDbContext data;
        private readonly IWebHostEnvironment environment;

        public EditAccountService(FlowerLoversDbContext _data, IWebHostEnvironment _environment) 
        {
            data = _data;
            environment = _environment;
        }

        public async Task EditAccount(EditAccountModel model, string userId)
        {
            var user = await data.Users.FindAsync(userId);

            if (user == null) 
            {
                throw new UserNullException(UserDataConstants.USER_NULL_MESSAGE);
            }

            var userAccount = await  data
                .UserAccounts
                .FirstOrDefaultAsync(ua => ua.Username == user.UserName);

            if (userAccount == null) 
            {
                throw new UserAccountNullException(UserAccountDataConstants.USER_ACCOUNT_ERROR_MESSAGE);
            }

            string relativePath = DownloadImage(model);

            if (relativePath != null)
            {
                userAccount.ImageUrl = relativePath;
            }

            if (model.Biography != null)
            {
                userAccount.Biography = model.Biography;
            }

            await data.SaveChangesAsync();
        }

        private string DownloadImage(EditAccountModel model)
        {
            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                // Get file name and path to the directory.
                string fileName = model.ImageFile.FileName;
                string relativePath = Path.Combine("Content", "Images", fileName);
                string absolutePath = Path.Combine(environment.WebRootPath, relativePath);

                // Get the directory or create it if it's not already.
                var directory = Path.GetDirectoryName(absolutePath);
                if (!Directory.Exists(directory) && directory != null)
                {
                    Directory.CreateDirectory(directory);
                }

                // Set the file to the directory.
                using (var stream = new FileStream(absolutePath, FileMode.Create))
                {
                    model.ImageFile.CopyTo(stream);
                }

                return relativePath;
            }

            return null;
        }
    }
}
