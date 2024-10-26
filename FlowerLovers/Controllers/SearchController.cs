using FlowerLovers.Core.Contracts.SearchServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlowerLovers.Web.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        private ISearchArticleService searchArticleService;

        public SearchController(
            ISearchArticleService _searchArticleService) 
        {
            searchArticleService = _searchArticleService;
        }

        [HttpGet]
        public IActionResult CategoryFilter() 
        {
            return View();
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
