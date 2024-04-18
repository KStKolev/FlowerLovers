using FlowerLovers.Core.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlowerLovers.Core.Contracts
{
    public interface ILogInService
    {
        public Task OnGetAsync();
        public Task<IActionResult> OnPostAsync(LogInModel model);
    }
}
