using System.Threading.Tasks;
using Supermarket.API.Resources;

namespace Supermarket.API.Domain.Services
{
    public interface IAddToCartService
    {
         Task<int> CalculateProductPrice(AddToCartResource[] addToCartResource);
    }
}