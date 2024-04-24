using FlowerLovers.Core.Contracts.SearchServices;
using FlowerLovers.Data.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlowerLovers.Web.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        private IFilterArticlesService filterArticlesService;
        private ISearchArticleService searchArticleService;

        public SearchController(IFilterArticlesService _filterArticlesService,
            ISearchArticleService _searchArticleService) 
        {
            filterArticlesService = _filterArticlesService;
            searchArticleService = _searchArticleService;
        }

        [HttpGet]
        public IActionResult CategoryFilter() 
        {
            return View();
        }


        public async Task<IActionResult> FilterArticles(string category, int currentPage = 1, int articlesPerPage = 3) 
        {
            var filteredArticles = await 
                filterArticlesService
                .FilteredArticles(category, currentPage, articlesPerPage);

            ViewBag.Category = category;

            return View(filteredArticles);
        }


        public async Task<IActionResult> SearchArticle(string articleName, int currentPage = 1, int articlesPerPage = 3) 
        {
            var searchedArticles = await 
                searchArticleService
                .SearchArticle(articleName, currentPage, articlesPerPage);

            if (searchedArticles.Articles.Count() == 0)
            {
                return RedirectToAction("MainPage", "Article");
            }

            ViewBag.ArticleName = articleName;

            return View(searchedArticles);
        }
    }
}
