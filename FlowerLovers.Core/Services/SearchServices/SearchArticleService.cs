using FlowerLovers.Core.Contracts.SearchServices;
using FlowerLovers.Core.Services.ArticleServices.Models;
using FlowerLovers.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace FlowerLovers.Core.Services.SearchServices
{
    public class SearchArticleService : ISearchArticleService
    {
        private FlowerLoversDbContext data;

        public SearchArticleService(FlowerLoversDbContext _data)
        {
            data = _data;
        }

        public async Task<ArticleModel> SearchArticle(string articleName, int currentPage, int articlesPerPage)
        {
            if (articleName == null)
            {
                throw new ArgumentException(nameof(articleName));
            }

            var articlesQuery = data.Articles.Where(a => a.Title == articleName);

            var totalItems = await articlesQuery.CountAsync(); // Calculate total items

            var articles = await articlesQuery
                .Skip((currentPage - 1) * articlesPerPage)
                .Take(articlesPerPage)
                .ToListAsync();

            var totalPages = (int)Math.Ceiling(totalItems / (double)articlesPerPage);

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
