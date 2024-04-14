using FlowerLovers.Core.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlowerLovers.Core.Contracts
{
    public interface IForgotPasswordService
    {
        public Task<IActionResult> OnPostAsync(ForgotPasswordModel model);
    }
}
