using FlowerLovers.Core.Contracts.AccountService;
using FlowerLovers.Core.Services.AccountServices.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FlowerLovers.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        private readonly IEditAccountService editAccountService;

        public AccountController(IAccountService _accountService,
            IEditAccountService _editAccountService) 
        {
            accountService = _accountService;
            editAccountService = _editAccountService;
        }

        [HttpGet]
        public async Task<IActionResult> AccountPage(int id) 
        {
            string userId = User.UserId();
            var account = await accountService.CreateUserAccount(id, userId);

            AccountPageModel model = new AccountPageModel()
            {
                Username = account.Username,
                UserAccountId = account.Id,
                ImageUrl = account.ImageUrl,
                Biography = account.Biography,
                Articles = account.Articles.Count(),
                DateOfCreation = account.CreationDate
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit() 
        {
            EditAccountModel model = new EditAccountModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditAccountModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string userId = User.UserId();
            await editAccountService.EditAccount(model, userId);

            return RedirectToAction("MainPage", "Article");
        }
    }
}
