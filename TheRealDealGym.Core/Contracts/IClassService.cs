using TheRealDealGym.Core.Models.Class;

namespace TheRealDealGym.Core.Contracts
{
    internal interface IClassService
    {
        Task<IEnumerable<ClassModel>> AllUserBookingsAsync();
    }
}
