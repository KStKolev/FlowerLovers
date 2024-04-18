using Microsoft.AspNetCore.Mvc;

namespace FlowerLovers.Core.Contracts
{
    public interface ILogOutService
    {
        public Task<IActionResult> OnPost();
    }
}
