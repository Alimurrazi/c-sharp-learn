using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Domain.Models;
using server.Domain.Services;
using MongoDB.Driver;

namespace server.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IMongoCollection<User> _users;

        public IdentityService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UserCollectionName);
        }

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }
    }
}
