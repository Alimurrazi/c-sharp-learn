using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Domain.Models;

namespace server.Domain.Services
{
    public interface IIdentityService
    {
        User Create(User user);
    }
}
