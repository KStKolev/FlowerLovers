namespace FlowerLovers.Core.Contracts.ApplicationServices
{
    public interface IApplicationServiceUser
    {
        Task<string> UserFullNameAsync(string userId);
    }
}
