using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Infrastructure.Data.Common;
using TheRealDealGym.Infrastructure.Data.Models;

namespace TheRealDealGym.Core.Services
{
    /// <summary>
    /// This service is responsible for ASP User.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IRepository repository;
        public UserService(IRepository _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// This method gets the given user full name.
        /// </summary>
        public async Task<string> UserFullNameAsync(Guid userId)
        {
            string result = string.Empty;
            var user = await repository.GetByIdAsync<ApplicationUser>(userId);

            if (user != null)
            {
                result = $"{user.FirstName} {user.LastName}";
            }

            return result;
        }
    }
}
