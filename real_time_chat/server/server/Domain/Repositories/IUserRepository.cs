using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Domain.Models;

namespace server.Domain.Repositories
{
    public interface IUserRepository
    {
        User Create(User user);
    }
}
