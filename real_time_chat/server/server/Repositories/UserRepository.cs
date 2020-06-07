using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using server.Domain.Models;
using server.Domain.Repositories;

namespace server.Repositories
{
    public class UserRepository: BaseRepository
    {
        private readonly IMongoCollection<User> _users;
        public UserRepository(IDatabaseSettings settings):base(settings)
        {
            _users = _database.GetCollection<User>(settings.UserCollectionName);
        }

        public void Create(User user)
        {
            _users.InsertOne(user);
        }
    }
}
