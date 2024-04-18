using FlowerLovers.Core.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlowerLovers.Core.Contracts
{
    public interface IDeletePersonalDataService
    {
        public Task<IActionResult> OnGetAsync(DeletePersonalDataModel model, string userId);
        public Task<IActionResult> OnPostAsync(DeletePersonalDataModel model, string userId);
    }
}
