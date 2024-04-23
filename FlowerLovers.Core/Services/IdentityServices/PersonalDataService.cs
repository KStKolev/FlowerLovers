using FlowerLovers.Core.Contracts.IdentityServices;
using FlowerLovers.Data.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlowerLovers.Core.Services.IdentityServices
{
    public class PersonalDataService : PageModel, IPersonalDataService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public PersonalDataService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound($"Unable to load user.");
            }

            return Page();
        }
    }
}
