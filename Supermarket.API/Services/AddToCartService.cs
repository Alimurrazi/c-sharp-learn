using System.Collections.Generic;
using Supermarket.API.Domain.Services;
using System.Threading.Tasks;
using Supermarket.API.Resources;

namespace Supermarket.API.Services
{
    public class AddToCartService: IAddToCartService
    {
        private List<int> GetProductIdList(AddToCartResource[] products){
            List<int> idList = new List<int>();
            foreach (var product in products)
            {
                idList.Add(product.ProductId);
            }
            return idList;
        }
        public async Task <int> CalculateProductPrice(AddToCartResource[] cartResource){
            List<int> idList = this.GetProductIdList(cartResource);
            return 0;
        }
    }
}