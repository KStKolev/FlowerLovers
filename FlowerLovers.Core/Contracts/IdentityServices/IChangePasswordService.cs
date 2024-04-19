using FlowerLovers.Core.Services.IdentityServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlowerLovers.Core.Contracts.IdentityServices
{
    public interface IChangePasswordService
    {
        public Task<IActionResult> OnGetAsync(string userId);
        public Task<IActionResult> OnPostAsync(ChangePasswordModel model, string userId);
    }
}
