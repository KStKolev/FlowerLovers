using FlowerLovers.Core.Services.IdentityServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlowerLovers.Core.Contracts.IdentityServices
{
    public interface IForgotPasswordService
    {
        public Task<IActionResult> OnPostAsync(ForgotPasswordModel model);
    }
}
