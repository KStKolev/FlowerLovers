using FlowerLovers.Core.Contracts.ArticleServices;
using FlowerLovers.Core.CustomExceptions;
using FlowerLovers.Core.CustomExceptions.DataConstants;
using FlowerLovers.Core.Services.AccountServices.Models.DataRequirements;
using FlowerLovers.Core.Services.ArticleServices.Models;
using FlowerLovers.Data.Data;
using FlowerLovers.Data.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace FlowerLovers.Core.Services.ArticleServices
{
    public class AddArticleService : IAddArticleService
    {
        private readonly FlowerLoversDbContext data;
        private readonly IWebHostEnvironment environment;

        public AddArticleService(FlowerLoversDbContext _data, IWebHostEnvironment _environment)
        {
            data = _data;
            environment = _environment;
        }

        public async Task AddArticle(string userId, AddArticleModel model)
        {
            if (userId == null || model == null)
            {
                throw new ArgumentException("Arguments are null!");
            }

            var user = await data.Users.FindAsync(userId);

            var userAccount = await data
                .UserAccounts
                .FirstOrDefaultAsync(ua => ua.Username == user.UserName);

            if (userAccount == null) 
            {
                throw new UserAccountNullException(nameof(userAccount));
            }

            string imagePath = DownloadImage(model);

            if (imagePath == null)
            {
                throw new ImageNullException(ImageDataConstants.IMAGE_MESSAGE_ERROR);
            }

            var category = await data
                .Categories
                .FirstOrDefaultAsync(c => c.Name == model.Category);

            if (category == null)
            {
                throw new CategoryNullException();
            }

            var newArticle = new Article()
            {
                Title = model.Title,
                Content = model.Content,
                UserAccountId = userAccount.Id,
                DateOfPublish = FormattedDateOfCreation(),
                CategoryId = category.Id,
                ImageUrl = imagePath
            };

            await data.Articles.AddAsync(newArticle);
            await data.SaveChangesAsync();
        }


        private string DownloadImage(AddArticleModel model)
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
