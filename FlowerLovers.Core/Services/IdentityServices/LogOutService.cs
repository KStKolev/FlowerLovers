using FlowerLovers.Core.Contracts;
using FlowerLovers.Data.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlowerLovers.Core.Services.IdentityServices
{
    public class LogOutService : PageModel, ILogOutService
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        public LogOutService(SignInManager<ApplicationUser> _signInManager)
        {
            signInManager = _signInManager;
        }

        public async Task<IActionResult> OnPost()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("LogOut", "Identity");
        }
    }
}
