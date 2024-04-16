using FlowerLovers.Core.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlowerLovers.Core.Contracts
{
    public interface IChangePasswordService
    {
        public Task<IActionResult> OnGetAsync();
        public Task<IActionResult> OnPostAsync(ChangePasswordModel model);
    }
}
