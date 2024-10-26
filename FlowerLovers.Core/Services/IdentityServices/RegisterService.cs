#nullable disable

using FlowerLovers.Core.Contracts.AccountService;
using FlowerLovers.Core.Contracts.IdentityServices;
using FlowerLovers.Core.Services.IdentityServices.Models;
using FlowerLovers.Data.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlowerLovers.Core.Services.IdentityServices
{
    public class RegisterService : PageModel, IRegisterService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IAccountService _accountService;

        public RegisterService(
                UserManager<ApplicationUser> userManager,
                IUserStore<ApplicationUser> userStore,
                SignInManager<ApplicationUser> signInManager,
                IAccountService accountService
            )
        {
            _userManager = userManager;
            _userStore = userStore;
            _signInManager = signInManager;
            _accountService = accountService;
        }

        public async Task<IActionResult> OnPostAsync(RegisterModel model)
        {
            var user = CreateUser();
            UserStoreExtension.SetUserNames(user, model.FirstName, model.LastName);
            UserStoreExtension.SetUserEmail(user, model.Email);
            string fullName = model.FirstName + model.LastName;
            await _userStore.SetUserNameAsync(user, fullName, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                await _accountService.CreateUserAccount(user.Id);
                return RedirectToAction("Register", "Identity");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return Page();
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
    }
}
