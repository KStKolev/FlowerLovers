using FlowerLovers.Core.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlowerLovers.Core.Contracts
{
    public interface ILogInService
    {
        public Task OnGetAsync(string returnUrl);
        public Task<IActionResult> OnPostAsync(LogInModel model, string returnUrl);
    }
}
