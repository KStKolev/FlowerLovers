using FlowerLovers.Core.Contracts.IdentityServices;
using FlowerLovers.Core.Services.IdentityServices.Models;
using FlowerLovers.Data.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlowerLovers.Core.Services.IdentityServices
{
    public class ResetPasswordService : PageModel, IResetPasswordService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ResetPasswordService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> OnPostAsync(ResetPasswordModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var ResetPasswordResult = await _userManager.ResetPasswordAsync(user, token, model.Password);
                if (!ResetPasswordResult.Succeeded) 
                {
                    foreach (var error in ResetPasswordResult.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }
                return RedirectToAction("ResetPassword", "Identity");
            }

            // Don't reveal that the user does not exist
            return RedirectToAction("Error", "Home");
        }
    }
}
