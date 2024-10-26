using FlowerLovers.Core.Contracts.IdentityServices;
using FlowerLovers.Core.Services.IdentityServices.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FlowerLovers.Web.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IRegisterService registerService;
        private readonly IResetPasswordService resetPasswordService;
        private readonly ILogInService logInService;
        private readonly IForgotPasswordService forgotPasswordService;
        private readonly ILogOutService logOutService;
        private readonly IChangePasswordService changePasswordService;

        public IdentityController(IRegisterService _registerService,
                ILogInService _logInService,
                IResetPasswordService _resetPasswordService,
                IForgotPasswordService _forgotPasswordService,
                ILogOutService _logOutService,
                IChangePasswordService _changePasswordService
            )
        {
            registerService = _registerService;
            logInService = _logInService;
            resetPasswordService = _resetPasswordService;
            forgotPasswordService = _forgotPasswordService;
            logOutService = _logOutService;
            changePasswordService = _changePasswordService;
        }

        //Register 
        [HttpGet]
        public IActionResult Register() 
        {
            RegisterModel model = new RegisterModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model) 
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await registerService.OnPostAsync(model);
            return RedirectToAction("MainPage", "Article");
        }

        // Log In
        [HttpGet]
        public async Task<IActionResult> LogIn() 
        {
            LogInModel model = new LogInModel();
            await logInService.OnGetAsync();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LogInModel model) 
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await logInService.OnPostAsync(model);
            return RedirectToAction("MainPage", "Article");
        }

        // Forgot password
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await forgotPasswordService.OnPostAsync(model);
            return RedirectToAction("ResetPassword", "Identity");
        }

        // Reset Password
        [HttpGet]
        public IActionResult ResetPassword()
        {
            ResetPasswordModel model = new ResetPasswordModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await resetPasswordService.OnPostAsync(model);
            return RedirectToAction(nameof(ResetPasswordConfirmation), "Identity");
        }

        // Reset password confirmation
        [HttpGet]
        public IActionResult ResetPasswordConfirmation() 
        {
            return View();
        }

        // Log out of account.
        [Authorize]
        public IActionResult LogOut() 
        {
            logOutService.OnPost();
            return RedirectToAction(nameof(Index), "Home");
        }

        // Change password of account.
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ChangePassword() 
        {
            string userId = User.UserId();
            await changePasswordService.OnGetAsync(userId);
            ChangePasswordModel model = new ChangePasswordModel();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model) 
        {
            string userId = User.UserId();
            await changePasswordService.OnPostAsync(model, userId);
            return RedirectToAction("MainPage", "Article");
        }
    }
}
