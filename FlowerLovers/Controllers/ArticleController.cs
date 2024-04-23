using FlowerLovers.Core.Contracts.ArticleServices;
using FlowerLovers.Core.Services.ArticleServices.Models;
using FlowerLovers.Data.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FlowerLovers.Web.Controllers
{
    [Authorize]
    public class ArticleController : Controller
    {
        private readonly IAddArticleService addArticleService;
        private readonly IArticleService articleServices;
        private readonly ISaveArticleService saveService;
        private readonly ISavedArticleService savedService;
        private readonly ILeaveArticleService leaveService;
        private readonly IDetailsArticleService detailsArticleService;
        private readonly IRateService rateService;
        private readonly IEditArticleService editArticleService;

        public ArticleController(
            IAddArticleService _addArticleService, 
            IArticleService _articleServices,
            ISaveArticleService _saveService,
            ISavedArticleService _savedService,
            ILeaveArticleService _leaveService,
            IDetailsArticleService _detailsArticleService,
            IRateService _rateService,
            IEditArticleService _editArticleService)
        {
            addArticleService = _addArticleService;
            articleServices = _articleServices;
            saveService = _saveService;
            savedService = _savedService;
            leaveService = _leaveService;
            detailsArticleService = _detailsArticleService;
            rateService = _rateService;
            editArticleService = _editArticleService;
        }

        [HttpGet]
        public async Task<IActionResult> MainPage() 
        {
            IEnumerable<ArticleModel> model = await articleServices
                .GetArticles();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add() 
        {
            AddArticleModel model = new AddArticleModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddArticleModel model) 
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string userId = User.UserId();
            await addArticleService.AddArticle(userId, model);
            return RedirectToAction(nameof(MainPage), nameof(Article));
        }

        [HttpPost]
        public async Task<IActionResult> Save(int articleId) 
         {
            var userId = User.UserId(); 
            await saveService.SaveArticle(articleId, userId);
            return RedirectToAction(nameof(Saved), nameof(Article));
        }

        [HttpGet]
        public async Task<IActionResult> Saved() 
        {
            string userId = User.UserId();
            var savedarticles = await savedService.SavedArticles(userId);
            return View(savedarticles);
        }

        public async Task<IActionResult> Leave(int articleId) 
        {
            string userId = User.UserId();
            await leaveService.LeaveSaved(articleId, userId);
            return RedirectToAction(nameof(Saved), nameof(Article));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int articleId) 
        {
            var detailsModel = await detailsArticleService.GetDetailsArticle(articleId);
            return View(detailsModel);
        }

        [HttpGet]
        public IActionResult Rate(int articleId) 
        {
            var rateModel = new RateModel()
            {
                ArticleId = articleId,
            };
            return View(rateModel);
        }

        [HttpPost]
        public async Task<IActionResult> Rate(RateModel model, int articleId) 
        {
            string userId = User.UserId();
            await rateService.RateArticle(model, articleId, userId);
            return RedirectToAction(nameof(MainPage), nameof(Article));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int articleId) 
        {
            string userId = User.UserId();
            var editArticleModel = await editArticleService.GetArticle(articleId, userId);
            return View(editArticleModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditArticleModel model, int articleId) 
        {
            await editArticleService.EditArticle(model, articleId);
            return RedirectToAction(nameof(MainPage), nameof(Article));
        }
    }
}
