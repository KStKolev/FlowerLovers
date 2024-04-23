using FlowerLovers.Core.Contracts.ArticleServices;
using FlowerLovers.Core.Services.ArticleServices.Models;
using FlowerLovers.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace FlowerLovers.Core.Services.ArticleServices
{
    public class ArticleServices : IArticleService
    {
        private readonly FlowerLoversDbContext data;

        public ArticleServices(FlowerLoversDbContext _data) 
        {
            data = _data;
        }

        public async Task<IEnumerable<ArticleModel>> GetArticles()
        {
            var articles = await data.Articles.Select(a => new ArticleModel
            (
                a.Id,
                a.Title,
                a.UserAccount.Username,
                a.UserAccount.ImageUrl,
                a.ImageUrl,
                a.Content
            ))
                .ToListAsync();

            return articles;
        }
    }
}
