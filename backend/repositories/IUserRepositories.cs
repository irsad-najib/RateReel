using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Repositories
{
    public interface IUserRepositories
    {
        Task<IEnumerable<UserModel>> GetAllUserAsync();
        Task<UserModel> GetUserByIdAsync(string id);
        Task<UserModel> AddUserAsync(UserModel user);
        Task<UserModel> UpdateUserAsync(UserModel user);
        Task DeleteUserAsync(string id);
    }
}