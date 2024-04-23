using FlowerLovers.Core.Contracts.ApplicationServices;
using FlowerLovers.Core.Services.ApplicationUserService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FlowerLovers.Web.Controllers
{
    [Authorize]
    public class RegisterController : Controller
    {
        private readonly IApplicationServiceUser userService;

        public RegisterController(IApplicationServiceUser _userService)
        {
            userService = _userService;
        }

        public async Task<IActionResult> Introducement() 
        {
            var userId = User.UserId();

            ApplicationUserModel model = new ApplicationUserModel();
            model.FullName = await userService.UserFullNameAsync(userId);

            return View(model);
        }
    }
}
