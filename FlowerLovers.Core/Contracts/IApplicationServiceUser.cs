namespace FlowerLovers.Core.Contracts
{
    public interface IApplicationServiceUser
    {
        Task<string> UserFullNameAsync(string userId);
    }
}
