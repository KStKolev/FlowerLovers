using FlowerLovers.Core.Services.IdentityServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlowerLovers.Core.Contracts.IdentityServices
{
    public interface IDeletePersonalDataService
    {
        public Task<IActionResult> OnGetAsync(DeletePersonalDataModel model, string userId);
        public Task<IActionResult> OnPostAsync(DeletePersonalDataModel model, string userId);
    }
}
