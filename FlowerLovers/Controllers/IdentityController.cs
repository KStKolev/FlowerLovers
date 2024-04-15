using FlowerLovers.Core.Contracts;
using FlowerLovers.Core.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlowerLovers.Web.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IRegisterService registerService;
        private readonly IResetPasswordService resetPasswordService;
        private readonly ILogInService logInService;
        private readonly IForgotPasswordService forgotPasswordService;

        public IdentityController(IRegisterService _registerService,
                ILogInService _logInService, 
                IResetPasswordService _resetPasswordService,
                IForgotPasswordService _forgotPasswordService
            )
        {
            registerService = _registerService;
            logInService = _logInService;
            resetPasswordService = _resetPasswordService;
            forgotPasswordService = _forgotPasswordService;
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
            return RedirectToAction(nameof(ResetPassword), "Identity");
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            await resetPasswordService.OnPostAsync(model);
            return RedirectToAction(nameof(ResetPasswordConfirmation), "Identity");
        }

        // Reset Password
        [HttpGet]
        public IActionResult ResetPassword() 
        {
            ResetPasswordModel model = new ResetPasswordModel();
            return View(model);
        }

        // Reset password confirmation
        [HttpGet]
        public IActionResult ResetPasswordConfirmation() 
        {
            return View();
        }
    }
}
