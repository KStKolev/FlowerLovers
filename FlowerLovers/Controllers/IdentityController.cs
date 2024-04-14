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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model) 
        {
            await registerService.OnPostAsync(model);
            return View(model);
        }

        // Log In
        [HttpGet]
        public async Task<IActionResult> LogIn(string returnUrl) 
        {
            await logInService.OnGetAsync(returnUrl);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInModel model, string returnUrl) 
        {
            await logInService.OnPostAsync(model, returnUrl);
            return View(model);
        }

        // Reset Password

        [Authorize]
        [HttpGet]
        public IActionResult ResetPassword(string code, ResetPasswordModel model) 
        {
            resetPasswordService.OnGet(code, model);
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model) 
        {
            await resetPasswordService.OnPostAsync(model);
            return View(model);
        }

        // Reset password confirmation
        [Authorize]
        [HttpGet]
        public IActionResult ResetPasswordConfirmation() 
        {
            return View();
        }

        // Forgot password
        [Authorize]
        [HttpGet]
        public IActionResult ForgotPassword() 
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model) 
        {
            await forgotPasswordService.OnPostAsync(model);
            return View(model);
        }
    }
}
