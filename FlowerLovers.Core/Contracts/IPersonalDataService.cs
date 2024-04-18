using Microsoft.AspNetCore.Mvc;

namespace FlowerLovers.Core.Contracts
{
    public interface IPersonalDataService
    {
        public Task<IActionResult> OnGetAsync(string userId);
    }
}
