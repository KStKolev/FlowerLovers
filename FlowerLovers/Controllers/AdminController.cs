using Microsoft.AspNetCore.Mvc;
using FlowerLovers.Core.CustomFilters;
using FlowerLovers.Core.Services.AdminService.Models;
using FlowerLovers.Core.Contracts.AdminServices;

namespace FlowerLovers.Web.Controllers
{
    [AdminFilter]
    public class AdminController : Controller
    {
        private IDeleteArticleService deleteArticleService;
        private IDeleteUserService deleteUserService;

        public AdminController(IDeleteArticleService _deleteArticleService, IDeleteUserService _deleteUserService)
        {
            deleteArticleService = _deleteArticleService;
            deleteUserService = _deleteUserService;
        }

        public IActionResult DeleteConfirm(int articleId)
        {
            DeleteArticleModel deleteArticleModel = new DeleteArticleModel
            {
                ArticleId = articleId,
            };
            return View(deleteArticleModel);
        }

        public async Task<IActionResult> Delete(int articleId)
        {
            await deleteArticleService.DeleteArticle(articleId);
            return RedirectToAction("MainPage", "Article");
        }

        public async Task<IActionResult> DeleteUser(int userAccountId)
        {
            await deleteUserService.DeleteUser(userAccountId);
            return RedirectToAction("MainPage", "Article");
        }
    }
}
