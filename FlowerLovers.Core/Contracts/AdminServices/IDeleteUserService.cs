namespace FlowerLovers.Core.Contracts.AdminServices
{
    public interface IDeleteUserService
    {
        public Task DeleteUser(int userAccountId);
    }
}
