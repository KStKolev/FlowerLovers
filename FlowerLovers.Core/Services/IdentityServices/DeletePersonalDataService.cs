using FlowerLovers.Core.Contracts;
using FlowerLovers.Core.Services.Models;
using FlowerLovers.Data.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlowerLovers.Core.Services.IdentityServices
{
    public class DeletePersonalDataService : PageModel, IDeletePersonalDataService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public DeletePersonalDataService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnGetAsync(DeletePersonalDataModel model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound($"Unable to load user.");
            }

            model.RequirePassword = await _userManager.HasPasswordAsync(user);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(DeletePersonalDataModel model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound($"Unable to load user.");
            }

            model.RequirePassword = await _userManager.HasPasswordAsync(user);

            if (model.RequirePassword)
            {
                if (!await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    ModelState.AddModelError(string.Empty, "Incorrect password.");
                    return Page();
                }
            }

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Unexpected error occurred deleting user.");
            }

            await _signInManager.SignOutAsync();

            return RedirectToAction("DeletePersonalData", "Identity");
        }
    }
}
