using Microsoft.AspNetCore.Mvc;

namespace FlowerLovers.Core.Contracts.IdentityServices
{
    public interface ILogOutService
    {
        public Task<IActionResult> OnPost();
    }
}
