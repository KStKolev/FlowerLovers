﻿using FlowerLovers.Data.Data.Models;

namespace FlowerLovers.Core.Contracts.AccountService
{
    public interface IAccountService
    {
        public Task<UserAccount> CreateUserAccount(string userId);
    }
}