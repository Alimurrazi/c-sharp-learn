using System.Threading.Tasks;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Repositories
{
    public interface ISuperShopRepository
    {
       Task <SuperShop> FindByAsync(int id);
    }
}