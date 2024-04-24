using FlowerLovers.Core.Contracts.ArticleServices;
using FlowerLovers.Core.CustomExceptions;
using FlowerLovers.Core.CustomExceptions.DataConstants;
using FlowerLovers.Core.Services.ArticleServices.Models;
using FlowerLovers.Data.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace FlowerLovers.Core.Services.ArticleServices
{
    public class EditArticleService : IEditArticleService
    {
        private readonly FlowerLoversDbContext data;
        private readonly IWebHostEnvironment environment;

        public EditArticleService(FlowerLoversDbContext _data,
            IWebHostEnvironment _environment)
        {
            data = _data;
            environment = _environment;
        }

        public async Task<EditArticleModel> GetArticle(int articleId, string userId)
        {
            if (userId == null)
            {
                throw new ArgumentException(nameof(userId));
            }

            var user = await data
                .Users
                .FindAsync(userId);

            if (user == null)
            {
                throw new UserNullException(UserDataConstants.USER_NULL_MESSAGE);
            }

            var articleToEdit = await data
                .Articles
                .FindAsync(articleId);

            if (articleToEdit == null)
            {
                throw new ArticleNullException(ArticleDataConstants.ARTICLE_ERROR_MESSAGE);
            }

            var editArticleModel = new EditArticleModel
            {
                ArticleId = articleId,
                Title = articleToEdit.Title,
                ImageUrl = articleToEdit.ImageUrl,
                Content = articleToEdit.Content,
                CategoryId = articleToEdit.CategoryId
            };

            if (editArticleModel == null)
            {
                throw new ArticleNullException(ArticleDataConstants.ARTICLE_ERROR_MESSAGE);
            }

            return editArticleModel;
        }

        public async Task EditArticle(EditArticleModel model, int articleId)
        {
            var articleToEdit = await data
                .Articles
                .FindAsync(articleId);

            if (articleToEdit == null)
            {
                throw new ArticleNullException(ArticleDataConstants.ARTICLE_ERROR_MESSAGE);
            }

            if (model.Title != null)
            {
                articleToEdit.Title = model.Title;
            }

            string newImageUrl = DownloadImage(model);
            if (newImageUrl != null)
            {
                articleToEdit.ImageUrl = newImageUrl;
            }

            if (model.Content != null)
            {
                articleToEdit.Content = model.Content;
            }

            if (model.Category != null)
            {
                var category = await data
                    .Categories
                    .FirstOrDefaultAsync(c => c.Name == model.Category);

                if (category != null)
                {
                    articleToEdit.CategoryId = category.Id;
                }
            }

            await data.SaveChangesAsync();
        }

        private string DownloadImage(EditArticleModel model)
        {
            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                //Get file name and path to the directory.
                string fileName = model.ImageFile.FileName;
                string relativePath = Path.Combine("Content", "Images", fileName);
                string absolutePath = Path.Combine(environment.WebRootPath, relativePath);

                //Get the directory or create it, if it's not already.
                var directory = Path.GetDirectoryName(absolutePath);
                if (!Directory.Exists(directory) && directory != null)
                {
                    Directory.CreateDirectory(directory);
                }

                bool isCreated = false;

                if (directory != null && Directory.GetFiles(directory, fileName).Length > 0)
                {
                    isCreated = true;
                }

                if (isCreated == false)
                {
                    // Set the file to the directory.
                    using (var stream = new FileStream(absolutePath, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(stream);
                    }
                }
                return relativePath;
            }

            return null;
        }
    }
}
