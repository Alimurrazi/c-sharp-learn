using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
namespace Supermarket.API.Domain.Repositories
{
    public interface IAddToCartRepository
    {
        Task<IEnumerable<Product>> GetProductListById(List<int> idList);
    }
}