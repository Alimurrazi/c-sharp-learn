using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Domain.Models;
using server.Domain.Services;
using server.Domain.Repositories;
using MongoDB.Driver;
using server.Repositories;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

namespace server.Services
{
    public class IdentityService : IIdentityService
    {
      //  private readonly IMongoCollection<User> _users;

        private readonly IUserRepository _userRepository;

        public IdentityService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        private string GetHashedPassword(string password)
        {
            string defaultSalt = "NZsP6NnmfBuYeJrrAKNuVQ==";
           // byte[] salt = new byte[128 / 8];
            byte[] salt = Encoding.ASCII.GetBytes(defaultSalt);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        public User Create(User user)
        {
            try
            {
                user.Password = this.GetHashedPassword(user.Password);
                user.Id = Guid.NewGuid().ToString();
                _userRepository.Create(user);
                return user;
            }
            catch(Exception ex)
            {

            }
        }
    }
}
