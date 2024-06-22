namespace TheRealDealGym.Core.Contracts
{
    public interface IUserService
    {
        Task<string> UserFullNameAsync(Guid userId);
    }
}
