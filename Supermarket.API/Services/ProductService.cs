using Supermarket.API.Domain.Services;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Supermarket.API.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository){
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> ListAsync(){
            return await _productRepository.ListAsync();
        }
    }
}