using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Backend.Models;
using Backend.Repositories;
using Backend.Configuration;

namespace Backend.Repositories
{
    public class UserRepository : IUserRepositories
    {
        private readonly IMongoCollection<UserModel> _users;

        public UserRepository(IOptions<DatabaseSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _users = database.GetCollection<UserModel>(settings.Value.UserCollectionName);
        }

        public async Task<IEnumerable<UserModel>> GetAllUserAsync()
        {
            return await _users.Find(u => true).ToListAsync();
        }

        public async Task<UserModel> GetUserByIdAsync(string id)
        {
            return await _users.Find(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<UserModel> AddUserAsync(UserModel user)
        {
            await _users.InsertOneAsync(user);
            return user;
        }

        public async Task<UserModel> UpdateUserAsync(UserModel user)
        {
            await _users.ReplaceOneAsync(u => u.Id == user.Id, user);
            return user;
        }

        public async Task DeleteUserAsync(string id)
        {
            await _users.DeleteOneAsync(u => u.Id == id);
        }
    }
}