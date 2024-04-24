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

        public async Task<ArticleModel> GetArticles(int currentPage, int articlesPerPage)
        {
            var totalItems = data.Articles.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)articlesPerPage);

            var articles = await data
                .Articles
                .Skip((currentPage - 1) * articlesPerPage)
                .Take(articlesPerPage)
                .ToListAsync();

            var articleModel = new ArticleModel
            {
                Articles = articles,
                CurrentPage = currentPage,
                TotalPages = totalPages
            };

            return articleModel;
        }
    }
}
