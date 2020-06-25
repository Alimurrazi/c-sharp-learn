using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Domain.Models;
using server.Responses;

namespace server.Domain.Services
{
    public interface IIdentityService
    {
        Task<BaseResponse> CreateUserAsync(User user);
        Task<BaseResponse> IsEmailExistsAsync(string mail);
    }
}
