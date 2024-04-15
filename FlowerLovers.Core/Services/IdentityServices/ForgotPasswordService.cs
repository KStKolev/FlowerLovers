using FlowerLovers.Data.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FlowerLovers.Core.Contracts;
using FlowerLovers.Core.Services.Models;

namespace FlowerLovers.Core.Services.IdentityServices
{
    public class ForgotPasswordService : PageModel, IForgotPasswordService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ForgotPasswordService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> OnPostAsync(ForgotPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    return RedirectToAction("Error", "Home");
                }
            }
            return RedirectToAction("ForgotPassword", "Identity");
        }
    }
}
