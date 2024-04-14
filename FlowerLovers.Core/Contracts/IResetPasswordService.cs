using FlowerLovers.Core.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlowerLovers.Core.Contracts
{
    public interface IResetPasswordService
    {
        public IActionResult OnGet(string code, ResetPasswordModel model);
        public Task<IActionResult> OnPostAsync(ResetPasswordModel model);
    }
}
