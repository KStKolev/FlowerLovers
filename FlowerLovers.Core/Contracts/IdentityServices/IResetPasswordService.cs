using FlowerLovers.Core.Services.IdentityServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlowerLovers.Core.Contracts.IdentityServices
{
    public interface IResetPasswordService
    {
        public Task<IActionResult> OnPostAsync(ResetPasswordModel model);
    }
}
