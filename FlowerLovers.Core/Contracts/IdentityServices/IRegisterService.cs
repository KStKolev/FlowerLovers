using FlowerLovers.Core.Services.IdentityServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlowerLovers.Core.Contracts.IdentityServices
{
    public interface IRegisterService
    {
        public Task<IActionResult> OnPostAsync(RegisterModel model);
    }
}
