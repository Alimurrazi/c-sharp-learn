using Supermarket.API.Domain.Services;
using System.Threading.Tasks;
using Supermarket.API.Resources;

namespace Supermarket.API.Services
{
    public class AddToCartService: IAddToCartService
    {
        public async Task <int> CalculateProductPrice(AddToCartResource[] cartResources){
            return 0;
        }
    }
}