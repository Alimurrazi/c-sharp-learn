﻿using System;
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
using server.Responses;

namespace server.Services
{
    public class IdentityService : IIdentityService
    {

        private readonly IUserRepository _userRepository;

        public IdentityService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        private string GetHashedPassword(string password)
        {
            string defaultSalt = "NZsP6NnmfBuYeJrrAKNuVQ==";
            byte[] salt = Encoding.ASCII.GetBytes(defaultSalt);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        public async Task<BaseResponse> CreateUserAsync(User user)
        {
            try
            {
                user.Password = this.GetHashedPassword(user.Password);
                user.Id = Guid.NewGuid().ToString();
                await _userRepository.CreateAsync(user);
                return new BaseResponse(true, null, null);
            }
            catch (Exception ex)
            {
                List<string> errorMsg = new List<string>();
                errorMsg.Add(ex.Message);
                return new BaseResponse(false, errorMsg, null);
            }
        }
    }
}
