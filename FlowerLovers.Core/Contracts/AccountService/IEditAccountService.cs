using FlowerLovers.Core.Services.AccountServices.Models;

namespace FlowerLovers.Core.Contracts.AccountService
{
    public interface IEditAccountService
    {
        public Task EditAccount(EditAccountModel model, string userId);
    }
}
