using Microsoft.AspNetCore.Identity;
using PublishingBusinessManagement.DTOs;
using PublishingBusinessManagement.Models;

namespace PublishingBusinessManagement.Repositories
{
    public interface IAccountRepository
    {
        Task<User> FindByNameAsync(string userName);
        Task<User> FindByEmailAsync(string email);
        Task<IdentityResult> CreateAsync(User user, string password);
        Task<IList<string>> GetRolesAsync(User user);
    }
}
