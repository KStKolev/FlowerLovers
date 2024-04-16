using FlowerLovers.Core.Contracts;
using FlowerLovers.Core.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Register(RegisterModel model) 
        {
            await registerService.OnPostAsync(model);
            return RedirectToAction(nameof(Index), "Home");
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
        public async Task<IActionResult> LogIn(LogInModel model) 
        {
            await logInService.OnPostAsync(model);
            return RedirectToAction(nameof(Index), "Home");
        }

        // Forgot password
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        {
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
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
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
            ChangePasswordModel model = new ChangePasswordModel();
            await changePasswordService.OnGetAsync();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model) 
        {
            await changePasswordService.OnPostAsync(model);
            return RedirectToAction(nameof(Index), "Identity");
        }
    }
}
