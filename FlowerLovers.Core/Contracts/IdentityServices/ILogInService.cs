using FlowerLovers.Core.Services.IdentityServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlowerLovers.Core.Contracts.IdentityServices
{
    public interface ILogInService
    {
        public Task OnGetAsync();
        public Task<IActionResult> OnPostAsync(LogInModel model);
    }
}
