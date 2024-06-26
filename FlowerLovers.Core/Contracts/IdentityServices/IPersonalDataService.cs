﻿using Microsoft.AspNetCore.Mvc;

namespace FlowerLovers.Core.Contracts.IdentityServices
{
    public interface IPersonalDataService
    {
        public Task<IActionResult> OnGetAsync(string userId);
    }
}
