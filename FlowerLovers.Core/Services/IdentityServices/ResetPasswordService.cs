using FlowerLovers.Core.Contracts;
using FlowerLovers.Core.Services.Models;
using FlowerLovers.Data.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlowerLovers.Core.Services.IdentityServices
{
    public class ResetPasswordService : PageModel, IResetPasswordService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;

        public ResetPasswordService(UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public async Task<IActionResult> OnPostAsync(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var forgotPasswordLink = Url.Action("ResetPassword", "Identity", new { token, email = user.Email });
                await _emailSender.SendEmailAsync(user.Email!, "Forgot Password link", forgotPasswordLink);
                return RedirectToAction("ResetPassword", "Identity");
            }

            // Don't reveal that the user does not exist
            return RedirectToAction("Error", "Home");
        }
    }
}
