using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using RealTimeChatApp.Models;

namespace RealTimeChatApp.Services
{
    public class ChatService
    {
        private readonly IMongoCollection<User> _users;
        public ChatService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<User>(settings.UserCollection);
            Console.WriteLine(_users);
        }

        public List<User> GetUser()
        {
            return _users.Find(user => true).ToList();
        }
        public User AddUser(User user)
        {
            _users.InsertOne(user);
            return user;
        }
    }
}
