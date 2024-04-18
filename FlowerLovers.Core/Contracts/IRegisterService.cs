using FlowerLovers.Core.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlowerLovers.Core.Contracts
{
    public interface IRegisterService
    {
        public Task<IActionResult> OnPostAsync(RegisterModel model);
    }
}
