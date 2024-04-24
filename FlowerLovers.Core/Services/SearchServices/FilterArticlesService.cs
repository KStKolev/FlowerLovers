using FlowerLovers.Core.Contracts.SearchServices;
using FlowerLovers.Core.CustomExceptions;
using FlowerLovers.Core.Services.ArticleServices.Models;
using FlowerLovers.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace FlowerLovers.Core.Services.SearchServices
{
    public class FilterArticlesService : IFilterArticlesService
    {
        private readonly FlowerLoversDbContext data;
        public FilterArticlesService(FlowerLoversDbContext _data) 
        {
            data = _data;
        }

        public async Task<ArticleModel> FilteredArticles(string category, int currentPage, int articlesPerPage)
        {
                if (category == null)
                {
                    throw new ArgumentException(nameof(category));
                }

                var categoryToFilter = await data
                .Categories
                .FirstOrDefaultAsync(c => c.Name == category);

                if (categoryToFilter == null)
                {
                    throw new CategoryNullException(nameof(categoryToFilter));
                }

                var totalItems = await data.Articles
                    .CountAsync(a => a.CategoryId == categoryToFilter.Id);

                var articles = await data.Articles
                    .Where(a => a.CategoryId == categoryToFilter.Id)
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
